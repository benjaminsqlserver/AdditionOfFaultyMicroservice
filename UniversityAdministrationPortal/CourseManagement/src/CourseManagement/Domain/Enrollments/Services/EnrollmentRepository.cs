namespace CourseManagement.Domain.Enrollments.Services;

using CourseManagement.Domain.Enrollments;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface IEnrollmentRepository : IGenericRepository<Enrollment>
{
}

public sealed class EnrollmentRepository(CourseManagementDbContext dbContext) : GenericRepository<Enrollment>(dbContext), IEnrollmentRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
