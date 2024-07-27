namespace FacultyManagement.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class Evaluators
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/evaluators";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/evaluators/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/evaluators/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/evaluators/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/evaluators/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/evaluators";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/evaluators/batch";
    }

    public static class Evaluations
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/evaluations";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/evaluations/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/evaluations/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/evaluations/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/evaluations/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/evaluations";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/evaluations/batch";
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

    public static class CourseAssignments
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/courseAssignments";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/courseAssignments/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/courseAssignments/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/courseAssignments/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/courseAssignments/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/courseAssignments";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/courseAssignments/batch";
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

    public static class Qualifications
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/qualifications";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/qualifications/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/qualifications/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/qualifications/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/qualifications/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/qualifications";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/qualifications/batch";
    }

    public static class Faculties
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/faculties";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/faculties/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/faculties/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/faculties/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/faculties/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/faculties";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/faculties/batch";
    }
}
