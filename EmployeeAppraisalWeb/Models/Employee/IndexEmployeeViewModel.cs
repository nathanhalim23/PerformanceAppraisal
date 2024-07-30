namespace EmployeeAppraisalWeb.Models.Employee
{
    public class IndexEmployeeViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
