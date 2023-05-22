using ApplicationEvaluation.App.Models;
using ApplicationEvaluation.App.Validators;
using FluentAssertions;
using Moq;

namespace ApplicationEvaluation.App.Test
{
    public class ApplicationEvaluationAppTest
    {
        public Application Application { get; set; }

        public ApplicationEvaluationAppTest()
        {
            Application = new Application()
            {
                MinRequiredAge = 22,
                Location = "Turkey",
                MinRequiredYearsOfExperience = 0,
                RequiredTitles = new List<string>()
                {
                    "Computer Engineer",
                    "Software Engineer",
                    "Computer Programmer"
                },
                RequiredSkills = new List<string>()
                {
                    ".Net Core",
                    "UnitTest",
                    "Entity Framework",
                    "Docker",
                    "SQL",
                    "NoSQL",
                    "RabbitMQ",
                    "CI/DI",
                    "Kubernets",
                    "Cloud"
                }
            };

            Application.Applicant = new Applicant()
            {
                IdentityNumber = "16177797780",
                FirstName = "Bulutay",
                LastName = "Saraç",
                Age = 24,
                Location = "USA",
                Title = "Computer Engineer",
                YearsOfExperience = 1,
                Skills = new List<string>()
                {
                    ".NET Core",
                    "UnitTest",
                    "Rest API",
                    "Microservice Arch",
                    "N-Tier Arch",
                    "MVC",
                    "Entity Framework",
                    "Docker",
                    "SQL",
                    "NoSQL",
                    "Redis"
                }
            };
        }

        [Fact]
        public void Application_FromForeignCountry_AutoRejected()
        {
            //Arrange
            var mockIdentityValidator = new Mock<IIdentityValidator>();
            mockIdentityValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);

            var mockAgeValidator = new Mock<IAgeValidator>();
            mockAgeValidator.Setup(i => i.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var mockExperienceValidator = new Mock<IExperienceValidator>();
            mockExperienceValidator.Setup(i => i.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var mockTitleValidator = new Mock<ITitleValidator>();
            mockTitleValidator.Setup(i => i.IsValid(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(true);

            var mockSkillRateValidator = new Mock<ISkillRateValidator>();
            mockSkillRateValidator.Setup(i => i.IsValid(It.IsAny<List<string>>(), It.IsAny<List<string>>())).Returns(true);

            ILocationValidator locationValidator = new LocationValidator();

            ApplicationEvaluator applicationEvaluator = new ApplicationEvaluator(mockIdentityValidator.Object, mockAgeValidator.Object, mockExperienceValidator.Object, mockTitleValidator.Object, locationValidator, mockSkillRateValidator.Object);

            //Action
            var result = applicationEvaluator.Evaulate(Application);

            //Assert
            //Assert.Equal(ApplicationResult.AutoRejected, result);
            result.Should().Be(ApplicationResult.AutoRejected);
        }

        [Fact]
        public void Application_InvalidAge_AutoRejected()
        {
            //Arrange
            this.Application.Applicant.Age = 1;
            //this.Application.Applicant.Age = 24;

            var mockIdentityValidator = new Mock<IIdentityValidator>();
            mockIdentityValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);

            var mockExperienceValidator = new Mock<IExperienceValidator>();
            mockExperienceValidator.Setup(i => i.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var mockTitleValidator = new Mock<ITitleValidator>();
            mockTitleValidator.Setup(i => i.IsValid(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(true);

            var mockSkillRateValidator = new Mock<ISkillRateValidator>();
            mockSkillRateValidator.Setup(i => i.IsValid(It.IsAny<List<string>>(), It.IsAny<List<string>>())).Returns(true);

            var mockLocationValidator = new Mock<ILocationValidator>();
            mockLocationValidator.Setup(i => i.IsValid(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            IAgeValidator ageValidator = new AgeValidator();

            ApplicationEvaluator applicationEvaluator = new ApplicationEvaluator(mockIdentityValidator.Object, ageValidator, mockExperienceValidator.Object, mockTitleValidator.Object, mockLocationValidator.Object, mockSkillRateValidator.Object);

            //Action
            var result = applicationEvaluator.Evaulate(Application);

            //Assert
            //Assert.Equal(ApplicationResult.AutoRejected, result);
            result.Should().Be(ApplicationResult.AutoRejected);
        }
    }
}