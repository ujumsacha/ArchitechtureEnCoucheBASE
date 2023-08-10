using BusinessLogic.User_Management.Implementations;
using BusinessLogic.User_Management.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using System.Net;
using System.Security.Claims;

namespace TEST
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PersonalAuth : AuthorizeAttribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["User"].Equals(false))
            {
                context.HttpContext.Response.Clear();
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.HttpContext.Response.WriteAsJsonAsync(new { code = "ERR001", Description = "Veuillez renseigner le tokken " });

            }

        }

       
    }

}
