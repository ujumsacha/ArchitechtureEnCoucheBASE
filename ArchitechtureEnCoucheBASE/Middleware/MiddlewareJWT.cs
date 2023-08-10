using BusinessLogic.User_Management.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArchitechtureEnCoucheBASE.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareJWT
    {
        
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IActionRoleService _actionrole;
        private readonly IUtilisateurService _UtilisateurService;
        public MiddlewareJWT(RequestDelegate next, IConfiguration configuration, IActionRoleService actionrole, IUtilisateurService utilisateurService)
        {
            _next = next;
            _configuration = configuration;
            _actionrole = actionrole;
            _UtilisateurService = utilisateurService;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (httpContext.Request.Path.ToUriComponent().Contains("Authentification"))
            {
                await _next(httpContext);


            }
            else
            {
                if (token != null)
                    attachAccountToContext(httpContext, token);

                
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsJsonAsync(new {code="ERR001",Description="Veuillez renseigner le tokken "});
                await _next(httpContext);
            }
            
        }

        private void attachAccountToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "iduser").Value;
                var roleId = jwtToken.Claims.First(x => x.Type == "Roleid").Value;
                var CompagnieId = jwtToken.Claims.First(x => x.Type == "CompagnieId").Value;
                string controller = context.Request.RouteValues["controller"].ToString();
                string action = context.Request.RouteValues["action"].ToString();
                // attach account to context on successful jwt validation
                context.Items["User"] = _actionrole.HaveAcces(roleId, controller.ToUpper(),action.ToUpper(), CompagnieId);
                
            }
            catch
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareJWTExtensions
    {
        public static IApplicationBuilder UseMiddlewareJWT(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareJWT>();
        }
    }
}
