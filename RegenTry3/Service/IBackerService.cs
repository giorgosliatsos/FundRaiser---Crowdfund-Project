using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegenTry3.dto;
using RegenTry3.Model;

namespace RegenTry3.Service
{
    public interface IBackerService
    {
        public ApiResponse<Backer> CreateBacker(Backer backer);

        public ApiResponse<Backer> GetBacker(int backerId);

        public ApiResponse<List<Backer>> GetBacker();

        public ApiResponse<bool> BackerExists(Backer backer);

    }
}
