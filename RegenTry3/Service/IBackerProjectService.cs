using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public interface IBackerProjectService
    {
        ApiResponse<BackerProject> AddBackerProject(int backerId, int projectId);

        ApiResponse<List<Project>> ReadBackerProjects(int backerId,List<Project> projects);
    }
}
