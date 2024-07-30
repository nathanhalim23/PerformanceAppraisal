using EmployeeAppraisalBusiness.Interfaces;
using EmployeeAppraisalDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppraisalBusiness.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;

        public EmployeeRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Employee> GetEmployees(int currentPage, int pageSize) 
        {
            var employees = _dbContext.Employees;
            return employees
                .Include("Division")
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public Employee GetByNik(string nik) {
            var employees = _dbContext.Employees;
            return employees
                .Include("Division")
                .Where(e => e.Nik == nik)
                .First();
        }


        public int CountData()
        {
            var employees = _dbContext.Employees;
            return employees.Count();
        }
    }
}
