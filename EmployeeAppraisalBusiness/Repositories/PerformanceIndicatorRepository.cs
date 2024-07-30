using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{
    public class PerformanceIndicatorRepository : IPerformanceIndicatorRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;

        public PerformanceIndicatorRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Insert(PerformanceIndicator model)
        {
            _dbContext.PerformanceIndicators.Add(model);
            _dbContext.SaveChanges();
        }
    }
}
