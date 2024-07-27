namespace FacultyManagement.Domain.Qualifications.Services;

using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface IQualificationRepository : IGenericRepository<Qualification>
{
}

public sealed class QualificationRepository(FacultyManagementDbContext dbContext) : GenericRepository<Qualification>(dbContext), IQualificationRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
