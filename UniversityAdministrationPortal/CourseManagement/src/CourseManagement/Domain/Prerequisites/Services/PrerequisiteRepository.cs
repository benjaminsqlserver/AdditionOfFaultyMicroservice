namespace CourseManagement.Domain.Prerequisites.Services;

using CourseManagement.Domain.Prerequisites;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface IPrerequisiteRepository : IGenericRepository<Prerequisite>
{
}

public sealed class PrerequisiteRepository(CourseManagementDbContext dbContext) : GenericRepository<Prerequisite>(dbContext), IPrerequisiteRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
