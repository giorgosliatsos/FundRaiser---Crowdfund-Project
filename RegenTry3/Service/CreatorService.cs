using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public class CreatorService: ICreatorService
    {

        private readonly CrmDbContext _db;

        public CreatorService(CrmDbContext db)
        {
            _db = db;
        }

        public ApiResponse<Creator> CreateCreator(Creator creator)
        {

            if (creator == null)
            {
                return new ApiResponse<Creator>()
                {
                    Data = null,
                    Description = "Creator Init Failed",
                    StatusCode = 1
                };
            }

            _db.Creators.Add(creator);
            try { _db.SaveChanges();}
            catch {
                return new ApiResponse<Creator>()
                {
                    Data = null,
                    Description = "Save to Database Failed",
                    StatusCode = 2
                };
            }

            return new ApiResponse<Creator>()
            {
                Data = creator,
                Description = "New Creator Created",
                StatusCode = 0
            };

        }

        public ApiResponse<Creator> GetCreator(int creatorId)
        {
            Creator creator = _db.Creators.Find(creatorId);

            if (creator != null) 
            { 
                return new ApiResponse<Creator>()
                {
                 Data = creator,
                    Description = "Creator Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<Creator>()
                {
                    Data = null,
                    Description = "Creator not Found",
                    StatusCode = 1
                };
            }
        }

        public ApiResponse<List<Creator>> GetCreator()
        {
            List<Creator> creators = _db.Creators.ToList();

            if (creators != null)
            {
                return new ApiResponse<List<Creator>>()
                {
                    Data = creators,
                    Description = $"{creators.Count()} Creators Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<List<Creator>>()
                {
                    Data = null,
                    Description = "0 Creators Found",
                    StatusCode = 1
                };
            }
        }

        public ApiResponse<List<Project>> GetCreatorProjects(int creatorId)
        {
            List<Project> creatorProjects = _db
                .Projects
                .Where(item => item.Creator.Id == creatorId)
                .ToList();

            if (creatorProjects == null)
            {
                return new ApiResponse<List<Project>>()
                {
                    Data = null,
                    Description = "This creator has C Projects",
                    StatusCode = 1
                };
            }
            else
            {
                return new ApiResponse<List<Project>>()
                {
                    Data = creatorProjects,
                    Description = $"This Creator has {creatorProjects.Count()} Projects",
                    StatusCode = 0
                };
            };
        }

        //public ApiResponse<bool> CreatorExists(Creator creator) {
        //    return new ApiResponse<bool>()
        //    {
        //        Data = (_db.Creators.Find(creator.Id)!=null),
        //        Description = "",
        //        StatusCode = 0
        //    };
        //}

        public ApiResponse<int> FindCreatorId(string username) {

            var creatorExists = _db.Creators.FirstOrDefault(creator => creator.Username == username);

            if( creatorExists == null)
            {
                return new ApiResponse<int>()
                {
                    Data = -1,
                    StatusCode = 0,
                    Description = "Creator not found"
            };
            }

            return new ApiResponse<int>()
            {
                Data = creatorExists.Id,
                StatusCode = 0,
                Description = "Creator found"
            };
        }
    }
}
