namespace FacultyManagement.Domain.Faculties.Services;

using FacultyManagement.Domain.Faculties;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface IFacultyRepository : IGenericRepository<Faculty>
{
}

public sealed class FacultyRepository(FacultyManagementDbContext dbContext) : GenericRepository<Faculty>(dbContext), IFacultyRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
