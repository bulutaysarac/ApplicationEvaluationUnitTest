namespace ApplicationEvaluation.App.Validators
{
    public interface IExperienceValidator
    {
        bool IsValid(int experienceOfApplicant, int minRequiredExperienceOfApplication);
    }
}