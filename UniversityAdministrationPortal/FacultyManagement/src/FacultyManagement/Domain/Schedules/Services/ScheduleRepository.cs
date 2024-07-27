namespace FacultyManagement.Domain.Schedules.Services;

using FacultyManagement.Domain.Schedules;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface IScheduleRepository : IGenericRepository<Schedule>
{
}

public sealed class ScheduleRepository(FacultyManagementDbContext dbContext) : GenericRepository<Schedule>(dbContext), IScheduleRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
