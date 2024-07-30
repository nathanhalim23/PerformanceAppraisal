using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;

        public FormRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }


        public AppraisalForm GetByNik(string nik)
        {
            var form = _dbContext.AppraisalForms
                .Where(f => f.Nik == nik)
                .OrderByDescending(f => f.Id)
                .First();

            return form;
        }


        public AppraisalForm Insert(AppraisalForm model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();

            return model;
        }
    }
}
