namespace CourseManagement.Domain.Instructors.Services;

using CourseManagement.Domain.Instructors;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface IInstructorRepository : IGenericRepository<Instructor>
{
}

public sealed class InstructorRepository(CourseManagementDbContext dbContext) : GenericRepository<Instructor>(dbContext), IInstructorRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
