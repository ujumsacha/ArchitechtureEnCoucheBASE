using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ArchitechtureEnCoucheBASE.Extensions
{
    public class AuthorizationExtension : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           string machaine  = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();
           string _Controller = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();
            

        }
    }
}

