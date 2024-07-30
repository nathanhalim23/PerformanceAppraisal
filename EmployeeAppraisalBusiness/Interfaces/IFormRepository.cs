using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Interfaces
{
    public interface IFormRepository
    {
        public AppraisalForm GetByNik(string nik);
        public AppraisalForm Insert(AppraisalForm model);
    }
}
