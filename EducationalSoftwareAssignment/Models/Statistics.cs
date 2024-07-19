namespace EducationalSoftwareAssignment.Models
{
    public class Statistics
    {
        public int Id { get; set; }
        public int Test_Id { get; set; }
        public float Grade { get; set; }
        public string Timer { get; set; }
        public string Username { get; set; }
        public string Answer1 {  get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public int IsCorrect { get; set; }

        public Test Test { get; set; }
    }
}
