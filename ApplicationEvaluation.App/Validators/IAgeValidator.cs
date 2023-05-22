namespace ApplicationEvaluation.App.Validators
{
    public interface IAgeValidator
    {
        bool IsValid(int ageOfApplicant, int minRequiredAgeOfApplication);
    }
}