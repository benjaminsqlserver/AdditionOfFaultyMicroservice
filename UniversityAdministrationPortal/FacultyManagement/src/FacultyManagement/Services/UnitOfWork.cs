namespace FacultyManagement.Services;

using FacultyManagement.Databases;

public interface IUnitOfWork : IFacultyManagementScopedService
{
    Task<int> CommitChanges(CancellationToken cancellationToken = default);
}

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly FacultyManagementDbContext _dbContext;

    public UnitOfWork(FacultyManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitChanges(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
