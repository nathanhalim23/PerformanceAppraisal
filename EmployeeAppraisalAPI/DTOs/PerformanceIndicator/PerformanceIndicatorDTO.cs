namespace EmployeeAppraisalAPI.DTOs.PerformanceIndicator
{
    public class PerformanceIndicatorDTO
    {
        public int Id { get; set; }
        public string Nik { get; set; }
        public string StrategicObjective { get; set; }
        public int? KpiId { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int? PolarizationId { get; set; }
        public int? Actual { get; set; }
        public int? FormId { get; set; }
    }
}
