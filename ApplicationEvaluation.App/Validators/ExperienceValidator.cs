namespace ApplicationEvaluation.App.Validators
{
    public class ExperienceValidator : IExperienceValidator
    {
        public bool IsValid(int experienceOfApplicant, int minRequiredExperienceOfApplication)
        {
            return experienceOfApplicant >= minRequiredExperienceOfApplication;
        }
    }
}