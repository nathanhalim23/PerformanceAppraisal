namespace EmployeeAppraisalAPI.DTOs.BasicCompetency
{
    public class BasicCompetencyInsertDTO
    {
        public int Id { get; set; }
        public string Nik { get; set; }
        public int FormId { get; set; }
        public int CustomerFocus { get; set; }
        public int Integrity { get; set; }
        public int Teamwork { get; set; }
        public int ContinuousImprovement { get; set; }
        public int WorkExcellence { get; set; }
    }
}
