namespace ApplicationEvaluation.App.Validators
{
    public class AgeValidator : IAgeValidator
    {
        public bool IsValid(int ageOfApplicant, int minRequiredAgeOfApplication)
        {
            return ageOfApplicant >= minRequiredAgeOfApplication;
        }
    }
}