namespace ApplicationEvaluation.App.Validators
{
    public class SkillRateValidator : ISkillRateValidator
    {
        public bool IsValid(List<string> skillsOfApplicant, List<string> requiredSkillsOfApplication)
        {
            int rate = requiredSkillsOfApplication.Intersect(skillsOfApplicant).ToList().Count / requiredSkillsOfApplication.Count * 100;

            if (rate < 50)
                return false;
            else
                return true;
        }
    }
}