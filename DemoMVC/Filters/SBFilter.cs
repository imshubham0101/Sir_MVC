using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Helpers;

namespace DemoMVC.Filters
{
    public class SBFilter : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;
            string msg = string.Format("/{0}/{1} is getting called", controller, method);

            Logger.CurrentLogger.Log(msg);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;
            string msg = string.Format("/{0}/{1} was called", controller, method);

            Logger.CurrentLogger.Log(msg);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = "";
            if (filterContext.Result is ViewResult)
            {
                string pageName = (filterContext.Result as ViewResult).ViewName;
                 msg = string.Format("{0} page is about to get processed", pageName);
            }
            else
            {
                msg = "Result Executed";
            }

            Logger.CurrentLogger.Log(msg);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = "";
            if (filterContext.Result is ViewResult)
            {
                string pageName = (filterContext.Result as ViewResult).ViewName;
                msg = string.Format("{0} page is processed", pageName);
            }
            else
            {
                msg = "Result Executed";
            }

            Logger.CurrentLogger.Log(msg);
        }

       
    }

}