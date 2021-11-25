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
        public ApiResponse<Project> ReadProject(int projectId);

        public ApiResponse<List<Project>> ReadProject();

        public ApiResponse<List<Project>> ReadProject(Category category);

        public ApiResponse<Project> UpdateProject(int projectId, Project project);

        public ApiResponse<bool> DeleteProject(int projectId);
    }
}
