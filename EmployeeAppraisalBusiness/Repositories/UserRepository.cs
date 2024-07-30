using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{

    public class UserRepository : IUserRepository
    {

        private readonly PerformanceAppraisalContext _dbContext;

        public UserRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUsers(string username)
        {
            var users = _dbContext.Users;
            return users.Find(username)
                ?? throw new Exception("Username or Password is incorrect!");
        }
    }
}
