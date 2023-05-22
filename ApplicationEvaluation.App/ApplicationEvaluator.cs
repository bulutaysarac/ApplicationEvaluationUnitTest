using ApplicationEvaluation.App.Models;
using ApplicationEvaluation.App.Validators;

namespace ApplicationEvaluation.App
{
    public class ApplicationEvaluator : IApplicationEvaluator
    {
        private readonly IIdentityValidator _identityValidator;
        private readonly IAgeValidator _ageValidator;
        private readonly IExperienceValidator _experienceValidator;
        private readonly ITitleValidator _titleValidator;
        private readonly ILocationValidator _locationValidator;
        private readonly ISkillRateValidator _skillRateValidator;

        public ApplicationEvaluator(IIdentityValidator identityValidator, IAgeValidator ageValidator, IExperienceValidator experienceValidator, ITitleValidator titleValidator, ILocationValidator locationValidator, ISkillRateValidator skillRateValidator)
        {
            _identityValidator = identityValidator;
            _ageValidator = ageValidator;
            _experienceValidator = experienceValidator;
            _titleValidator = titleValidator;
            _locationValidator = locationValidator;
            _skillRateValidator = skillRateValidator;
        }

        public ApplicationResult Evaulate(Application application)
        {
            if (!_ageValidator.IsValid(application.Applicant.Age, application.MinRequiredAge))
                return ApplicationResult.AutoRejected;

            if (!_experienceValidator.IsValid(application.Applicant.YearsOfExperience, application.MinRequiredYearsOfExperience))
                return ApplicationResult.AutoRejected;

            if (!_titleValidator.IsValid(application.Applicant.Title, application.RequiredTitles))
                return ApplicationResult.AutoRejected;

            if (!_locationValidator.IsValid(application.Applicant.Location, application.Location))
                return ApplicationResult.AutoRejected;

            if (!_identityValidator.IsValid(application.Applicant.IdentityNumber))
                return ApplicationResult.RedirectedToHR;

            if (!_skillRateValidator.IsValid(application.Applicant.Skills, application.RequiredSkills))
                return ApplicationResult.AutoRejected;

            return ApplicationResult.AutoAccepted;
        }
    }
}