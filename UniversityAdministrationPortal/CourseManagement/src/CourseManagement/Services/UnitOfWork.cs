namespace CourseManagement.Services;

using CourseManagement.Databases;

public interface IUnitOfWork : ICourseManagementScopedService
{
    Task<int> CommitChanges(CancellationToken cancellationToken = default);
}

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CourseManagementDbContext _dbContext;

    public UnitOfWork(CourseManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitChanges(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
