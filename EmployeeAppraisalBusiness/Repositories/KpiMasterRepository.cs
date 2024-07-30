using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{
    public class KpiMasterRepository : IKpiMasterRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;

        public KpiMasterRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<KpiMaster> GetKpiMasters()
        {
            var kpi = _dbContext.KpiMasters;
            return kpi.ToList();
        }
    }
}
