namespace EducationalSoftwareAssignment.Models
{
    public class Statistics
    {
        public int Id { get; set; }
        public int Test_Id { get; set; }
        public float Grade { get; set; }
        public string Timer { get; set; }
        public string Username { get; set; }

        public Test Test { get; set; }
    }
}
