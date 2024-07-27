namespace FacultyManagement.SharedTestHelpers.Fakes.Evaluation;

using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Domain.Evaluations.Models;

public class FakeEvaluationBuilder
{
    private EvaluationForCreation _creationData = new FakeEvaluationForCreation().Generate();

    public FakeEvaluationBuilder WithModel(EvaluationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeEvaluationBuilder WithFacultyID(Guid facultyID)
    {
        _creationData.FacultyID = facultyID;
        return this;
    }
    
    public FakeEvaluationBuilder WithEvaluationDate(DateTime evaluationDate)
    {
        _creationData.EvaluationDate = evaluationDate;
        return this;
    }
    
    public FakeEvaluationBuilder WithEvaluator(string evaluator)
    {
        _creationData.Evaluator = evaluator;
        return this;
    }
    
    public FakeEvaluationBuilder WithComments(string comments)
    {
        _creationData.Comments = comments;
        return this;
    }
    
    public FakeEvaluationBuilder WithRating(int rating)
    {
        _creationData.Rating = rating;
        return this;
    }
    
    public FakeEvaluationBuilder WithEvaluatorID(Guid evaluatorID)
    {
        _creationData.EvaluatorID = evaluatorID;
        return this;
    }
    
    public Evaluation Build()
    {
        var result = Evaluation.Create(_creationData);
        return result;
    }
}