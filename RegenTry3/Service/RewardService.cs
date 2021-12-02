using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegenTry3.dto;
using RegenTry3.Model;

namespace RegenTry3.Service
{
    public class RewardService : IRewardService
    {

        private readonly CrmDbContext _db;

        public RewardService(CrmDbContext db)
        {
            _db = db;
        }
        public ApiResponse<Reward> CreateReward(Reward reward)
        {
            if (reward == null)
            {
                return new ApiResponse<Reward>()
                {
                    Data = null,
                    Description = "Reward was null ",
                    StatusCode = 1
                };
            }

            _db.Rewards.Add(reward);
            try { _db.SaveChanges(); }

            catch
            {
                return new ApiResponse<Reward>()
                {
                    Data = null,
                    Description = "Reward not Saved to Database",
                    StatusCode = 2
                };
            }
            
            return new ApiResponse<Reward>()
            {
                Data = reward,
                Description = "Reward Succesfully Posted",
                StatusCode = 0
            };
            
        }

        public ApiResponse<Reward> CreateReward(Reward reward, int projectId)
        {
            if (reward == null || projectId<0)
            {
                return new ApiResponse<Reward>()
                {
                    Data = null,
                    Description = "Reward was null ",
                    StatusCode = 1
                };
            }


            reward.Project = _db.Projects.Find(projectId);
            
            //reward.Project.Rewards.Append(reward);

            _db.Rewards.Add(reward);
            try { _db.SaveChanges(); }

            catch
            {
                return new ApiResponse<Reward>()
                {
                    Data = null,
                    Description = "Reward not Saved to Database",
                    StatusCode = 2
                };
            }

            return new ApiResponse<Reward>()
            {
                Data = reward,
                Description = "Reward Succesfully Posted",
                StatusCode = 0
            };

        }

        public ApiResponse<bool> DeleteReward(int rewardId)
        {
            var reward = _db.Rewards.Find(rewardId);
            if (reward == null) return new ApiResponse<bool>() { Data = false, Description = "Reward was Null", StatusCode = 1 };

            _db.Rewards.Remove(reward);
            if (_db.SaveChanges() == 1)
            {
                return new ApiResponse<bool>() { Data = true, Description = "Reward Succesfully Deleted", StatusCode = 0 };
            }
            else
            {
                return new ApiResponse<bool>() { Data = false, Description = "Reward Delete Failed", StatusCode = 2 };
            }
        }

        public ApiResponse<Reward> ReadReward(int rewardId)
        {
            if (_db.Rewards.Find(rewardId) != null)
            {
                return new ApiResponse<Reward>()
                {
                    Data = _db.Rewards.Find(rewardId),
                    Description = "Reward Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<Reward>()
                {
                    Data = null,
                    Description = "Reward not Found",
                    StatusCode = 1
                };
            }
        }


        public ApiResponse<Reward> UpdateReward(int rewardId, Reward reward)
        {
            var dbReward = _db.Rewards.Find(rewardId);
            if (dbReward == null) throw new KeyNotFoundException();
            dbReward.Title = reward.Title;
            dbReward.Description = reward.Description;
            dbReward.Price = reward.Price;
            dbReward.Project = reward.Project;
            dbReward.Backers = reward.Backers;
            dbReward.BackerRewards = reward.BackerRewards;

            _db.SaveChanges();
            return new ApiResponse<Reward>()
            {
                Data = dbReward,
                Description = "Reward Succesfully Updated",
                StatusCode = 0
            };
        }
    }
}
