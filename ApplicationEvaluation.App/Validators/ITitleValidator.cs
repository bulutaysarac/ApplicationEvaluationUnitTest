namespace ApplicationEvaluation.App.Validators
{
    public interface ITitleValidator
    {
        bool IsValid(string titleOfApplicant, List<string> requiredTitlesOfApplication);
    }
}