namespace ApplicationEvaluation.App.Validators
{
    public interface ISkillRateValidator
    {
        bool IsValid(List<string> skillsOfApplicant, List<string> requiredSkillsOfApplication);
    }
}