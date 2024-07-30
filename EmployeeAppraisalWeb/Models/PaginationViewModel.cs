namespace EmployeeAppraisalWeb.Models
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
        public int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((double)TotalRows / PageSize);
            }
        }
    }
}
