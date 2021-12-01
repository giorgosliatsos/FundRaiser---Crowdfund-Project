using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegenTry3.dto;
using RegenTry3.Model;

namespace RegenTry3.Service
{
    public interface IProjectService
    {
        public ApiResponse<Project> CreateProject(Project project);

        public Project CreateProject(Project project, int creatorId);
        public ApiResponse<Project> ReadProject(int projectId);

        public ApiResponse<List<Project>> ReadProject();

        public ApiResponse<List<Project>> ReadProjectByCategory(int categoryId);

        public ApiResponse<List<Project>> ReadProjectByCategory(int categoryId, int creatorId);

        public ApiResponse<Project> UpdateProject(int projectId, Project project);

        public ApiResponse<Project> UpdatePost(int projectId, String newPost);

        public ApiResponse<Project> UpdateProjectReward(int projectId, Reward reward);

        public ApiResponse<bool> DeleteProject(int projectId);
    }
}
