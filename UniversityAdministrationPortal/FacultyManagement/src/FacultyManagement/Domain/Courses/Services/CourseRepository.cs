namespace FacultyManagement.Domain.Courses.Services;

using FacultyManagement.Domain.Courses;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface ICourseRepository : IGenericRepository<Course>
{
}

public sealed class CourseRepository(FacultyManagementDbContext dbContext) : GenericRepository<Course>(dbContext), ICourseRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
