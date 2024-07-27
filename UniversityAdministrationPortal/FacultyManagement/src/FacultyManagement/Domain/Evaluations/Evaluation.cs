namespace FacultyManagement.Domain.Evaluations;

using System.ComponentModel.DataAnnotations;
using FacultyManagement.Domain.Faculties;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.Evaluations.Models;
using FacultyManagement.Domain.Evaluations.DomainEvents;


public class Evaluation : BaseEntity
{
    public Guid FacultyID { get; private set; }

    public DateTime EvaluationDate { get; private set; }

    public string Evaluator { get; private set; }

    public string Comments { get; private set; }

    public int Rating { get; private set; }

    public Guid EvaluatorID { get; private set; }

    public Faculty Faculty { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Evaluation Create(EvaluationForCreation evaluationForCreation)
    {
        var newEvaluation = new Evaluation();

        newEvaluation.FacultyID = evaluationForCreation.FacultyID;
        newEvaluation.EvaluationDate = evaluationForCreation.EvaluationDate;
        newEvaluation.Evaluator = evaluationForCreation.Evaluator;
        newEvaluation.Comments = evaluationForCreation.Comments;
        newEvaluation.Rating = evaluationForCreation.Rating;
        newEvaluation.EvaluatorID = evaluationForCreation.EvaluatorID;

        newEvaluation.QueueDomainEvent(new EvaluationCreated(){ Evaluation = newEvaluation });
        
        return newEvaluation;
    }

    public Evaluation Update(EvaluationForUpdate evaluationForUpdate)
    {
        FacultyID = evaluationForUpdate.FacultyID;
        EvaluationDate = evaluationForUpdate.EvaluationDate;
        Evaluator = evaluationForUpdate.Evaluator;
        Comments = evaluationForUpdate.Comments;
        Rating = evaluationForUpdate.Rating;
        EvaluatorID = evaluationForUpdate.EvaluatorID;

        QueueDomainEvent(new EvaluationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Evaluation() { } // For EF + Mocking
}
