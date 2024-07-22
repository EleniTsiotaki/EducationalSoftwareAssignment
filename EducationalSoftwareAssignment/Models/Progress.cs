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
        public int Course11Visits { get; set; }
        public int Course12Visits { get; set; }
        public int Course13Visits { get; set; }
        public int Course21Visits { get; set; }
        public int Course22Visits { get; set; }
        public int Course23Visits { get; set; }
        public int Course31Visits { get; set; }
        public int Course32Visits { get; set; }
        public int Course33Visits { get; set; }


    }
}
