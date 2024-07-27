namespace CourseManagement.Domain.Resources.Mappings;

using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Domain.Resources.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ResourceMapper
{
    public static partial ResourceForCreation ToResourceForCreation(this ResourceForCreationDto resourceForCreationDto);
    public static partial ResourceForUpdate ToResourceForUpdate(this ResourceForUpdateDto resourceForUpdateDto);
    public static partial ResourceDto ToResourceDto(this Resource resource);
    public static partial IQueryable<ResourceDto> ToResourceDtoQueryable(this IQueryable<Resource> resource);
}