namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluator;

using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Domain.Evaluators.Models;

public class FakeEvaluatorBuilder
{
    private EvaluatorForCreation _creationData = new FakeEvaluatorForCreation().Generate();

    public FakeEvaluatorBuilder WithModel(EvaluatorForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeEvaluatorBuilder WithEvaluatorName(string evaluatorName)
    {
        _creationData.EvaluatorName = evaluatorName;
        return this;
    }
    
    public FakeEvaluatorBuilder WithEvaluatorEmail(string evaluatorEmail)
    {
        _creationData.EvaluatorEmail = evaluatorEmail;
        return this;
    }
    
    public Evaluator Build()
    {
        var result = Evaluator.Create(_creationData);
        return result;
    }
}