using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

namespace ChallengeSND.API.Helpers
{
    public class AuthorizationHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));

            var hasAuthorize = context.MethodInfo.DeclaringType?.GetCustomAttribute<AuthorizeAttribute>() != null ||
                               context.MethodInfo.GetCustomAttribute<AuthorizeAttribute>() != null;

            if (hasAuthorize)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();

                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            }
        }
    }
}

