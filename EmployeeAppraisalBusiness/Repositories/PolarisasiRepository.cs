using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{
    public class PolarisasiRepository : IPolarisasiRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;

        public PolarisasiRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<PolarizationMaster> GetPolarizationMasters()
        {
            var polar = _dbContext.PolarizationMasters;
            return polar.ToList();
        }

    }
}
