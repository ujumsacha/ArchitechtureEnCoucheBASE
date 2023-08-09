using BusinessLogic.User_Management.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using System.Net;
using System.Security.Claims;

namespace TEST
{
    public class PersonalAuth : AuthorizeAttribute
    {
        private readonly IActionRoleService _action;
        public PersonalAuth(IActionRoleService action)
        {
            _action = action;
        }

        public async Task OnAuthorization(AuthorizationFilterContext context)
        //public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Get controller name and Controller action 
            string controller = context.HttpContext.Request.RouteValues["controller"].ToString();
            string action = context.HttpContext.Request.RouteValues["action"].ToString();
            string roleuser = context.HttpContext.User.Claims.Where(p => p.Value == "Role").ToString();
            string compagnie = context.HttpContext.User.Claims.Where(p => p.Value == "CompagnieId").ToString();
            //Check if user have acces to controller name and action 

            bool res = await _action.HaveAcces(roleuser, controller, action, compagnie);
            if (!res)
            {
                
            }
            else
            {

            }
        }
    }

}
