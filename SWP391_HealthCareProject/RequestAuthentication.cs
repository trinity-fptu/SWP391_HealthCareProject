using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject
{
    public class RequestAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if(context.HttpContext.Session.GetObjectFromJson<User>("User") != null) { return; }
            //var controller = context.HttpContext.Request.RouteValues["controller"].ToString();
            //var action = context.HttpContext.Request.RouteValues["action"].ToString();
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
                //    Console.WriteLine(controller + "and" + action);
                //    context.Result = new RedirectToRouteResult(
                //        new RouteValueDictionary
                //        {
                //            {"controller", controller },
                //            {"action", action }
                //        }
                //        );
                //}
                return;
            }
            
            base.OnActionExecuting(context);
        }
    }
}
