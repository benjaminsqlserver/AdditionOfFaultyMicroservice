namespace CourseManagement.Domain.Resources.Services;

using CourseManagement.Domain.Resources;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface IResourceRepository : IGenericRepository<Resource>
{
}

public sealed class ResourceRepository(CourseManagementDbContext dbContext) : GenericRepository<Resource>(dbContext), IResourceRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
