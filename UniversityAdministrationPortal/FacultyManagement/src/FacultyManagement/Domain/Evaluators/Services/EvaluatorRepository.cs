namespace FacultyManagement.Domain.Evaluators.Services;

using FacultyManagement.Domain.Evaluators;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface IEvaluatorRepository : IGenericRepository<Evaluator>
{
}

public sealed class EvaluatorRepository(FacultyManagementDbContext dbContext) : GenericRepository<Evaluator>(dbContext), IEvaluatorRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
