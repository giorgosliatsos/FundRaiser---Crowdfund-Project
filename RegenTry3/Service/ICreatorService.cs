using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegenTry3.dto;
using RegenTry3.Model;

namespace RegenTry3.Service
{
    public interface ICreatorService
    {
        public ApiResponse<Creator> CreateCreator(Creator creator);

        public ApiResponse<Creator> GetCreator(int creatorId);

        public ApiResponse<List<Creator>> GetCreator();

        //public ApiResponse<bool> CreatorExists(Creator creator);

        public ApiResponse<List<Project>> GetCreatorProjects(int creatorId);

        public ApiResponse<int> FindCreatorId(string username);
    }
}
