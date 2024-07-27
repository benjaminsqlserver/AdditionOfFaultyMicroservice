namespace FacultyManagement.Domain.Evaluations.Services;

using FacultyManagement.Domain.Evaluations;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface IEvaluationRepository : IGenericRepository<Evaluation>
{
}

public sealed class EvaluationRepository(FacultyManagementDbContext dbContext) : GenericRepository<Evaluation>(dbContext), IEvaluationRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
