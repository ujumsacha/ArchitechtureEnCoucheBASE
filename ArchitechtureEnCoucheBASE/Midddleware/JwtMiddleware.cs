using ArchitechtureEnCoucheBASE.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace ArchitechtureEnCoucheBASE.Midddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToUriComponent().Contains("Authentification"))
            {

                return _next(httpContext);

            }
            else
            {
                string mytokken = httpContext.Request.Headers.Authorization;
                if (mytokken == null || mytokken == "")
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.WriteAsJsonAsync(new { Code = "SEC001", description = "Tokken incorrect ou non renseigné" });
                    return Task.CompletedTask;
                }
                if (!mytokken.Contains("Bearer "))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.WriteAsJsonAsync(new { Code = "SEC001", description = "Tokken incorrect ou non renseigné" });
                    return Task.CompletedTask;
                }
                mytokken = mytokken.Replace("Bearer ", String.Empty);
                string recup = CryptoClass.Decrytp(mytokken);
                httpContext.Request.Headers.Authorization = $"Bearer {recup}";

                return _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder JwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
