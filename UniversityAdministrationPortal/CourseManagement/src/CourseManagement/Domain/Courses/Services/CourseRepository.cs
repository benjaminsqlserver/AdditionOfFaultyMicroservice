namespace CourseManagement.Domain.Courses.Services;

using CourseManagement.Domain.Courses;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface ICourseRepository : IGenericRepository<Course>
{
}

public sealed class CourseRepository(CourseManagementDbContext dbContext) : GenericRepository<Course>(dbContext), ICourseRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
