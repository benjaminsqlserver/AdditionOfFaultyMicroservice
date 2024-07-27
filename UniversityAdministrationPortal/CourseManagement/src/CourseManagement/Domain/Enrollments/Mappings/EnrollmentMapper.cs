namespace CourseManagement.Domain.Enrollments.Mappings;

using CourseManagement.Domain.Enrollments.Dtos;
using CourseManagement.Domain.Enrollments.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class EnrollmentMapper
{
    public static partial EnrollmentForCreation ToEnrollmentForCreation(this EnrollmentForCreationDto enrollmentForCreationDto);
    public static partial EnrollmentForUpdate ToEnrollmentForUpdate(this EnrollmentForUpdateDto enrollmentForUpdateDto);
    public static partial EnrollmentDto ToEnrollmentDto(this Enrollment enrollment);
    public static partial IQueryable<EnrollmentDto> ToEnrollmentDtoQueryable(this IQueryable<Enrollment> enrollment);
}