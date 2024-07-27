namespace CourseManagement.Domain.LectureHalls.Services;

using CourseManagement.Domain.LectureHalls;
using CourseManagement.Databases;
using CourseManagement.Services;

public interface ILectureHallRepository : IGenericRepository<LectureHall>
{
}

public sealed class LectureHallRepository(CourseManagementDbContext dbContext) : GenericRepository<LectureHall>(dbContext), ILectureHallRepository
{
    private readonly CourseManagementDbContext _dbContext = dbContext;
}  
