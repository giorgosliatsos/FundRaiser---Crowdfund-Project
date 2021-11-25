using RegenTry3.dto;
using RegenTry3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Service
{
    public class BackerService : IBackerService
    {

        private readonly CrmDbContext _db;

        public BackerService(CrmDbContext db)
        {
            _db = db;
        }
        public ApiResponse<Backer> CreateBacker(Backer backer)
        {
            if (backer == null)
            {
                return new ApiResponse<Backer>()
                {
                    Data = null,
                    Description = "Backer Init Failed",
                    StatusCode = 1
                };
            }

            _db.Backers.Add(backer);
            try { _db.SaveChanges(); }
            catch
            {
                return new ApiResponse<Backer>()
                {
                    Data = null,
                    Description = "Save to Database Failed",
                    StatusCode = 2
                };
            }

            return new ApiResponse<Backer>()
            {
                Data = backer,
                Description = "New Backer Created",
                StatusCode = 0
            };
        }

        public ApiResponse<Backer> GetBacker(int backerId)
        {
            Backer backer = _db.Backers.Find(backerId);

            if (backer != null)
            {
                return new ApiResponse<Backer>()
                {
                    Data = backer,
                    Description = "Backer Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<Backer>()
                {
                    Data = null,
                    Description = "Backer not Found",
                    StatusCode = 1
                };
            }
        }

        public ApiResponse<List<Backer>> GetBacker()
        {
            List<Backer> backers = _db.Backers.ToList();

            if (backers != null)
            {
                return new ApiResponse<List<Backer>>()
                {
                    Data = backers,
                    Description = $"{backers.Count()} Backers Found",
                    StatusCode = 0
                };
            }
            else
            {
                return new ApiResponse<List<Backer>>()
                {
                    Data = null,
                    Description = "0 Backers Found",
                    StatusCode = 1
                };
            }
        }
    }
}
