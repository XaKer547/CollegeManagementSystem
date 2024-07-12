using CollegeManagementSystem.Domain.Helpers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml.Linq;

namespace CollegeManagementSystem.API.SchemaFilters;

public class EnumTypesSchemaFilter : ISchemaFilter
{
    private readonly XDocument _xmlComments;

    public EnumTypesSchemaFilter(string xmlPath)
    {
        if (File.Exists(xmlPath))
        {
            _xmlComments = XDocument.Load(xmlPath);
        }
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (_xmlComments == null)
            return;

        if (schema.Enum != null && schema.Enum.Count > 0 &&
            context.Type != null && context.Type.IsEnum)
        {
            schema.Description += "<p>Значения:</p><ul>";

            foreach (var enumMemberName in schema.Enum.OfType<OpenApiString>().Select(v => v.Value))
            {
                var a = (Enum)Enum.Parse(context.Type, enumMemberName);

                schema.Description += $"<li><i>{enumMemberName}</i> - {a.GetDisplayName()}</li>";
            }

            schema.Description += "</ul>";
        }
    }
}