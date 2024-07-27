namespace CourseManagement.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class Prerequisites
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/prerequisites";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/prerequisites/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/prerequisites/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/prerequisites/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/prerequisites/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/prerequisites";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/prerequisites/batch";
    }

    public static class Resources
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/resources";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/resources/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/resources/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/resources/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/resources/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/resources";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/resources/batch";
    }

    public static class LectureHalls
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/lectureHalls";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/lectureHalls/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/lectureHalls/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/lectureHalls/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/lectureHalls/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/lectureHalls";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/lectureHalls/batch";
    }

    public static class Enrollments
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/enrollments";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/enrollments/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/enrollments/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/enrollments/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/enrollments/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/enrollments";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/enrollments/batch";
    }

    public static class Students
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/students";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/students/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/students/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/students/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/students/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/students";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/students/batch";
    }

    public static class Instructors
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/instructors";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/instructors/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/instructors/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/instructors/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/instructors/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/instructors";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/instructors/batch";
    }

    public static class Schedules
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/schedules";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/schedules/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/schedules/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/schedules/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/schedules/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/schedules";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/schedules/batch";
    }

    public static class Courses
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/courses";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/courses/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/courses/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/courses/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/courses/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/courses";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/courses/batch";
    }
}
