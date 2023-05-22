namespace ApplicationEvaluation.App.Models
{
    public class Application
    {
        public Applicant Applicant { get; set; }
        public List<string> RequiredSkills { get; set; }
        public List<string> RequiredTitles { get; set; }
        public int MinRequiredYearsOfExperience { get; set; }
        public int MinRequiredAge { get; set; }
        public string Location { get; set; }

        public int CalculateSkillsRate()
        {
            return RequiredSkills.Intersect(Applicant.Skills).ToList().Count / RequiredSkills.Count * 100;
        }
    }

    public enum ApplicationResult
    {
        AutoAccepted,
        RedirectedToHR,
        AutoRejected
    }
}