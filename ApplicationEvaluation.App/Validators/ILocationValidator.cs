namespace ApplicationEvaluation.App.Validators
{
    public interface ILocationValidator
    {
        bool IsValid(string locationOfApplicant, string locationOfApplication);
    }
}