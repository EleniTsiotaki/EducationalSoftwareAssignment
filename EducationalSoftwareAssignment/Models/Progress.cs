namespace EducationalSoftwareAssignment.Models
{
    public class Progress
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public float TotalGrade { get; set; }
        public decimal AverageGrade { get; set; }
        public int SucceededTests { get; set; }
        public int FailedTests { get; set; }
        public int BeginnerTests { get; set; }
        public int IntermediateTests { get; set; }
        public int AdvancedTests { get; set; }
        public double BeginnerAverage { get; set; }
        public double IntermediateAverage { get; set; }
        public double AdvancedAverage { get; set; }
        public double TotalTime { get; set; }
        public DateTime DateTime { get; set; }
    }
}
