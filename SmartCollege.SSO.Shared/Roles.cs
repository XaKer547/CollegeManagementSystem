using System.ComponentModel.DataAnnotations;

namespace SmartCollege.SSO.Shared;

public enum Roles
{
    [Display(Name = "Студент")]
    Student,

    [Display(Name = "Преподаватель")]
    Teacher,

    [Display(Name = "Заведующий отделением")]
    HeadOfDepartment,

    [Display(Name = "Классный руководитель")]
    ClassroomTeacher,

    [Display(Name = "Представитель компании")]
    RepresentativeOfTheCompany
}

