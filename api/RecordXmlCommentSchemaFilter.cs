using System.Xml.XPath;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace openapi_clients.Controllers;

public class RecordXmlCommentSchemaFilter : ISchemaFilter
{
    private readonly XPathNavigator _xmlNavigator;

    public RecordXmlCommentSchemaFilter(XPathDocument xmlDoc)
    {
        _xmlNavigator = xmlDoc.CreateNavigator();
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo != null)
        {
            ApplyMemberTags(schema, context);
        }
    }

    private void ApplyMemberTags(OpenApiSchema schema, SchemaFilterContext context)
    {
        var fieldOrPropertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(context.MemberInfo.DeclaringType);
        var fieldOrPropertyNode = _xmlNavigator.SelectSingleNode(
            $"/doc/members/member[@name='{fieldOrPropertyMemberName}']/param[@name='{context.MemberInfo.Name}']");

        if (fieldOrPropertyNode == null) return;

        var summaryNode = fieldOrPropertyNode.GetAttribute("summary", string.Empty);
        if (summaryNode != null)
            schema.Description = XmlCommentsTextHelper.Humanize(summaryNode);

        var exampleNode = fieldOrPropertyNode.GetAttribute("example", string.Empty);
        if (exampleNode != null)
        {
            var exampleAsJson = (schema.ResolveType(context.SchemaRepository) == "string") && !"null".Equals(exampleNode)
                ? $"\"{exampleNode}\""
                : exampleNode.ToString();

            schema.Example = OpenApiAnyFactory.CreateFromJson(exampleAsJson);
        }
    }
}