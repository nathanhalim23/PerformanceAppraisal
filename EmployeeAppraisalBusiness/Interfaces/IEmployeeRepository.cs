using EmployeeAppraisalDataAccess.Models;


namespace EmployeeAppraisalBusiness.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees(int currentPage, int pageSize);

        public Employee GetByNik(string nik);
        public int CountData();
    }
}
