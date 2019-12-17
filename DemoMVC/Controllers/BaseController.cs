using DemoMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    [Authorize]
    [SBFilter]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class BaseController : Controller
    {
    }
}