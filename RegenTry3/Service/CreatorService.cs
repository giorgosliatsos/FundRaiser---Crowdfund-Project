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

        public ApiResponse<Project> CreateProject(Project project)
        {

            if (project == null)
            {
                return new ApiResponse<Project>()
                {
                    Data = null,
                    Description = "Project was null ",
                    StatusCode = 1
                };
            }

            _db.Projects.Add(project);
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                return new ApiResponse<Project>()
                {
                    Data = null,
                    Description = "Project not Saved to Database",
                    StatusCode = 2
                };
            }

            return new ApiResponse<Project>()
            {
                Data = project,
                Description = "Project Succesfully Created",
                StatusCode = 0
            };
        }

        public ApiResponse<Project> ReadProject(int projectId)
        {

            if (_db.Projects.Find(projectId) != null)
            {
                return new ApiResponse<Project>()
                {
                    Data = _db.Projects.Find(projectId),
                    Description = "Project Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<Project>()
                {
                    Data = null,
                    Description = "Project not Found",
                    StatusCode = 1
                };
            }

        }

        public ApiResponse<Project> UpdateProject(int projectId, Project project)
        {
            var dbProject = _db.Projects.Find(projectId);
            if (dbProject == null) throw new KeyNotFoundException();
            dbProject.Title = project.Title;
            dbProject.Description = project.Description;
            dbProject.Videos = project.Videos;
            dbProject.Photos = project.Photos;
            dbProject.Posts = project.Posts;
            dbProject.Rewards = project.Rewards;
            dbProject.Backers = project.Backers;
            dbProject.MoneyEarned = project.MoneyEarned;
            dbProject.Creator = project.Creator;
            dbProject.BackerProjects = project.BackerProjects;


            _db.SaveChanges();
            return new ApiResponse<Project>()
            {
                Data = dbProject,
                Description = "Project Succesfully Updated",
                StatusCode = 0
            };
        }

        public ApiResponse<bool> DeleteProject(int projectId)
        {
            var project = _db.Projects.Find(projectId);
            if (project == null) return new ApiResponse<bool>() { Data = false, Description = "Project was Null", StatusCode = 1 };

            _db.Projects.Remove(project);
            if (_db.SaveChanges() == 1)
            {
                return new ApiResponse<bool>() { Data = true, Description = "Project Succesfully Deleted", StatusCode = 0 };
            }
            else
            {
                return new ApiResponse<bool>() { Data = false, Description = "Project Delete Failed", StatusCode = 2 };
            }
        }
    }
}
