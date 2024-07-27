namespace CourseManagement.Domain.Students.Services;

using CourseManagement.Domain.Students;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface IStudentRepository : IGenericRepository<Student>
{
}

public sealed class StudentRepository(CourseManagementDbContext dbContext) : GenericRepository<Student>(dbContext), IStudentRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
