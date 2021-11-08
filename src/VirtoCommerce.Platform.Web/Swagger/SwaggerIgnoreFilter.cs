using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Web.Swagger
{
    /// <summary>
    /// Allows to ignore <see cref="Newtonsoft.Json.JsonIgnoreAttribute"/> and <see cref="SwaggerIgnoreAttribute"/>.
    /// </summary>
    public class SwaggerIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;
            foreach (var name in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                                     .Where(
                                        prop => prop.GetCustomAttributes(typeof(SwaggerIgnoreAttribute), true)?.Any() == true ||
                                        prop.GetCustomAttributes(typeof(Newtonsoft.Json.JsonIgnoreAttribute), true)?.Any() == true)
                                      .Select(p => p.Name))
            {
                var propName = name[0].ToString().ToLower() + name.Substring(1);
                if (schema?.Properties?.ContainsKey(propName) == true)
                    schema?.Properties?.Remove(propName);
            }
        }
    }
}
