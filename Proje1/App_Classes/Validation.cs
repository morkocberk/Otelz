using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace xx.App_Classes
{
    public class BlockedOut : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {                
                if (u.IsLockedOut)
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "x",
                        action = "y"
                    }));
                }
                
            }
            base.OnActionExecuted(filterContext);
        }
    }
}