using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Filters
{
    public class RequestAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObjectFromJson<User>("User") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Login" },
                        {"action", "Index" }
                    }
                    );
            }
            else
            {
                var controller = context.HttpContext.Request.RouteValues["controller"].ToString();
                Console.WriteLine(controller);
                if(controller == "RH")
                {
                    if(context.HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin") == null)
                    {
                        context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                        
                    }
                } else if(controller == "Admin")
                {
                    var user = context.HttpContext.Session.GetObjectFromJson<User>("User");
                    if (user.Role != 3)
                    {
                        context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                    }
                }
                return;
            }
            
            base.OnActionExecuting(context);
        }
    }
}
