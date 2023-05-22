namespace ApplicationEvaluation.App.Validators
{
    public class IdentityValidator : IIdentityValidator
    {
        public bool IsValid(string identityNumber)
        {
            return true;
        }
    }
}