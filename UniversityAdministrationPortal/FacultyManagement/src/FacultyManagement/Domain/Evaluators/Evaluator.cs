namespace FacultyManagement.Domain.Evaluators;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using FacultyManagement.Exceptions;
using FacultyManagement.Domain.Evaluators.Models;
using FacultyManagement.Domain.Evaluators.DomainEvents;


public class Evaluator : BaseEntity
{
    public string EvaluatorName { get; private set; }

    public string EvaluatorEmail { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Evaluator Create(EvaluatorForCreation evaluatorForCreation)
    {
        var newEvaluator = new Evaluator();

        newEvaluator.EvaluatorName = evaluatorForCreation.EvaluatorName;
        newEvaluator.EvaluatorEmail = evaluatorForCreation.EvaluatorEmail;

        newEvaluator.QueueDomainEvent(new EvaluatorCreated(){ Evaluator = newEvaluator });
        
        return newEvaluator;
    }

    public Evaluator Update(EvaluatorForUpdate evaluatorForUpdate)
    {
        EvaluatorName = evaluatorForUpdate.EvaluatorName;
        EvaluatorEmail = evaluatorForUpdate.EvaluatorEmail;

        QueueDomainEvent(new EvaluatorUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Evaluator() { } // For EF + Mocking
}