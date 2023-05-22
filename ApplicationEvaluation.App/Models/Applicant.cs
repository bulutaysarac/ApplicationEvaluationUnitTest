namespace ApplicationEvaluation.App.Models
{
    public class Applicant
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public int YearsOfExperience { get; set; }
        public string Location { get; set; }
        public List<string> Skills { get; set; }
    }
}