namespace CourseManagement.SharedTestHelpers.Fakes.LectureHall;

using CourseManagement.Domain.LectureHalls;
using CourseManagement.Domain.LectureHalls.Models;

public class FakeLectureHallBuilder
{
    private LectureHallForCreation _creationData = new FakeLectureHallForCreation().Generate();

    public FakeLectureHallBuilder WithModel(LectureHallForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeLectureHallBuilder WithRoomNumber(string roomNumber)
    {
        _creationData.RoomNumber = roomNumber;
        return this;
    }
    
    public FakeLectureHallBuilder WithCapacity(int capacity)
    {
        _creationData.Capacity = capacity;
        return this;
    }
    
    public LectureHall Build()
    {
        var result = LectureHall.Create(_creationData);
        return result;
    }
}