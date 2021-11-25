using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public interface IRewardService
    {
        public ApiResponse<Reward> CreateReward(Reward reward);
        public ApiResponse<Reward> ReadReward(int rewardId);

        public ApiResponse<Reward> UpdateReward(int rewardId, Reward reward);

        public ApiResponse<bool> DeleteReward(int rewardId);
    }
}
