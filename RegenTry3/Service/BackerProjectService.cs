using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public class BackerProjectService : IBackerProjectService
    {
        private readonly CrmDbContext _db;

        public BackerProjectService(CrmDbContext db)
        {
            _db = db;
        }

        public ApiResponse<BackerProject> AddBackerProject(int projectId, int backerId)
        {
            var backer = _db.Backers.Find(backerId);
            var project = _db.Projects.Find(projectId);
            if (backer == null || project == null)
            {
                return new ApiResponse<BackerProject>() { Data = null, Description = "Backer or Project doesnt exist.", StatusCode = 1 };
            }
            else
            {
                var newBackerProject = new BackerProject() { Backer = backer, Project = project };
                _db.BackerProjects.Add(newBackerProject);
                if (_db.SaveChanges() == 1) return new ApiResponse<BackerProject>() { Data = newBackerProject, Description = "Backer funded Project.", StatusCode = 0 };
                else return new ApiResponse<BackerProject>() { Data = null, Description = "Database save failed.", StatusCode = 2 };
            }
        }

        public ApiResponse<List<Project>> ReadBackerProjects(int backerId, List<Project> projects)
        {
            var backer = _db.Backers.Find(backerId);
            if (backer != null)
            {
                var fundedProjects = _db.BackerProjects.Where(item => (item.Backer.Id == backerId));
                if (fundedProjects==null) return new ApiResponse<List<Project>>() { Data = null, Description = "Backer hasnt funded any project yet.", StatusCode = 1 };
                else { 
                    return new ApiResponse<List<Project>>() 
                    {   
                        Data = fundedProjects.Select(item=>item.Project).Distinct().ToList().Intersect(projects).ToList(),Description = "Backer doesnt exist.", 
                        StatusCode = 1 
                    };
                }
            }
            else return new ApiResponse<List<Project>>() { Data = null, Description = "Backer doesnt exist.", StatusCode = 1 };
        }
    }
}
