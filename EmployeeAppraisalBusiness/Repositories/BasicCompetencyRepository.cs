using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{
    public class BasicCompetencyRepository : IBasicCompetencyRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;

        public BasicCompetencyRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Insert(BasicCompetency model)
        {
            _dbContext.BasicCompetencies.Add(model);
            _dbContext.SaveChanges();
        }
    }
}
