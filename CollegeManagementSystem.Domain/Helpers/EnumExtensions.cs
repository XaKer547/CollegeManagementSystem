using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CollegeManagementSystem.Domain.Helpers
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();

            return attribute?.GetName();
        }

        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
