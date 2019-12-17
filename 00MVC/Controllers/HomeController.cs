using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _00MVC.Models;

namespace _00MVC.Controllers
{
    public class HomeController : Controller
    {
      public ActionResult Display()
        {
            Emp emp = new Emp() { No = 1, Name = "abc" , Address = "pune" };
            return View("meraview",emp);
        }

        public ActionResult DisplayAll()
        {
            List<Emp> emps = new List<Emp>()
            {
                new Emp() { No = 11, Name = "abc1", Address = "pune1" },
                new Emp() { No = 12, Name = "abc2", Address = "pune2" },
                new Emp() { No = 13, Name = "abc3", Address = "pune3" },
                new Emp() { No = 14, Name = "abc4", Address = "pune4" },
                new Emp() { No = 15, Name = "abc5", Address = "pune5" }
            };

            return View("teraview", emps);
        }
    }
}