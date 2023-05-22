using static System.Net.Mime.MediaTypeNames;

namespace ApplicationEvaluation.App.Validators
{
    public class TitleValidator : ITitleValidator
    {
        public bool IsValid(string titleOfApplicant, List<string> requiredTitlesOfApplication)
        {
            return requiredTitlesOfApplication.Contains(titleOfApplicant);
        }
    }
}