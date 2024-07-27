namespace CourseManagement.Domain.Schedules.Services;

using CourseManagement.Domain.Schedules;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface IScheduleRepository : IGenericRepository<Schedule>
{
}

public sealed class ScheduleRepository(CourseManagementDbContext dbContext) : GenericRepository<Schedule>(dbContext), IScheduleRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
