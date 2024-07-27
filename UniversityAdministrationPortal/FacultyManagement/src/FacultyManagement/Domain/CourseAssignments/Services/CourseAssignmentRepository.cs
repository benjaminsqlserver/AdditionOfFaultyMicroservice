namespace FacultyManagement.Domain.CourseAssignments.Services;

using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Databases;
using FacultyManagement.Services;

public interface ICourseAssignmentRepository : IGenericRepository<CourseAssignment>
{
}

public sealed class CourseAssignmentRepository(FacultyManagementDbContext dbContext) : GenericRepository<CourseAssignment>(dbContext), ICourseAssignmentRepository
{
    private readonly FacultyManagementDbContext _dbContext = dbContext;
}  
