using ApplicationEvaluation.App.Models;

namespace ApplicationEvaluation.App
{
    public interface IApplicationEvaluator
    {
        ApplicationResult Evaulate(Application application);
    }
}