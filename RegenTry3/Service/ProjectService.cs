using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public class ProjectService : IProjectService

    {
        private readonly CrmDbContext _db;

        public ProjectService(CrmDbContext db)
        {
            _db = db;
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

        public ApiResponse<List<Project>> ReadProject()
        {
            return new ApiResponse<List<Project>>()
            {
                Data = _db.Projects.ToList(),
                Description = "",
                StatusCode = 0
            };
        }

        public ApiResponse<List<Project>> ReadProjectByCategory(int categoryId)
        {
            if (categoryId == 0) return ReadProject();
            else return new ApiResponse<List<Project>>()
                {
                    Data = _db.Projects.Where(item => (int)item.Category == categoryId).ToList(),
                    Description = "",
                    StatusCode = 0
                };
            
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
            dbProject.MoneyGoal = project.MoneyGoal;
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

        public ApiResponse<Project> UpdateProjectReward(int projectId, Reward reward)
        {
            var dbProject = _db.Projects.Find(projectId);
            if (dbProject == null) throw new KeyNotFoundException();

            dbProject.Rewards.Add(reward);
            _db.SaveChanges();
            return new ApiResponse<Project>()
            {
                Data = dbProject,
                Description = "Project Succesfully Updated",
                StatusCode = 0
            };
        }

        public Project CreateProject(Project project, int creatorId)
        {

            if (project == null) return null;
            project.Creator = _db.Creators.Find(creatorId);

            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
        }

        public ApiResponse<List<Project>> ReadProjectByCategory(int categoryId, int creatorId)
        {

            var creatorsProjects = _db.Projects.Where(cr => (int)cr.Creator.Id == creatorId).ToList();
            if (creatorsProjects == null) return new ApiResponse<List<Project>>()
            {
                Data = null,
                Description = "Creator Doesnt Exist",
                StatusCode = 1
            };


            if (categoryId == 0) return new ApiResponse<List<Project>>()
            {
                Data = creatorsProjects,
                Description = "",
                StatusCode = 0
            };
            else return new ApiResponse<List<Project>>()
            {
                Data = creatorsProjects.Where(item => (int)item.Category == categoryId).ToList(),
                Description = "",
                StatusCode = 0
            };

        }

        public ApiResponse<Project> UpdatePost(int projectId, string newPost)
        {
            var updatedProject = _db.Projects.Find(projectId);

            if (newPost != null)
            {
                updatedProject.Posts = newPost;
                _db.SaveChanges();
            }
                
            return new ApiResponse<Project>()
            {
                Data = updatedProject,
                Description = "Post updated",
                StatusCode = 0
            };
            
        }
    }
}
