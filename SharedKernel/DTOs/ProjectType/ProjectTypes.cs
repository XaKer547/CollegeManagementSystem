using System.ComponentModel.DataAnnotations;

namespace SharedKernel.DTOs.ProjectType;

public enum ProjectTypes
{
    [Display(Name = "Курсовая работа")]
    CourseWork,
    [Display(Name = "Дипломная работа")]
    GraduateWork
}
