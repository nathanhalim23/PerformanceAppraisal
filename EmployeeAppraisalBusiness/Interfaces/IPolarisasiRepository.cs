﻿using EmployeeAppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Interfaces
{
    public interface IPolarisasiRepository
    {
        public List<PolarizationMaster> GetPolarizationMasters();
    }
}
