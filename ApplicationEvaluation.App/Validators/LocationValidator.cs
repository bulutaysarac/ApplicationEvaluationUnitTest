namespace ApplicationEvaluation.App.Validators
{
    public class LocationValidator : ILocationValidator
    {
        public bool IsValid(string locationOfApplicant, string locationOfApplication)
        {
            return locationOfApplicant.Equals(locationOfApplication);
        }
    }
}