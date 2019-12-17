using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;
using DemoMVC.Filters;
using System.Web.Routing;
using System.Data.SqlClient;
using DemoMVC.Helpers;

namespace DemoMVC.Controllers
{
    //[Authorize]
    //[SBFilter]
    //[HandleError(ExceptionType = typeof(Exception), View = "Error")]
    //public class HomeController : Controller
    public class HomeController : BaseController
    {
        SampleEntities dbObject = new SampleEntities();

        //[SBFilter]
        //[Authorize]
        public ActionResult Index()
        {
            return View("Index", dbObject.Emps.ToList());
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        //[HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult AfterCreate(Emp emp)
        {
            dbObject.Emps.Add(emp);
            dbObject.SaveChanges();
            #region Try Catch

            //try
            //{
            //    dbObject.Emps.Add(emp);
            //    dbObject.SaveChanges();
            //}
            //catch(Exception ex)
            //{
            //    Logger.CurrentLogger.Log("Exception! Details:" + ex.Message );   
            //    return View("Error", ex);
            //}

            #endregion
            return Redirect("/Home/Index");
        }

        //public ActionResult Edit(int no, string name, string address)
        public ActionResult Edit(int id)
        {
            Emp empSearched = dbObject.Emps.Find(id);
            return View("Edit", empSearched);
        }

        //public ActionResult AfterEdit(FormCollection enitreForm)
        //public ActionResult AfterEdit(Student s)
        public ActionResult AfterEdit(Emp emp)
        {
            Emp oldEmp = dbObject.Emps.Find(emp.No);
            oldEmp.Name = emp.Name;
            oldEmp.Address = emp.Address;
            dbObject.SaveChanges();
            return Redirect("/Home/Index");
        }

        public ActionResult Delete(int id)
        {
            Emp empToBeDeleted = dbObject.Emps.Find(id);
            dbObject.Emps.Remove(empToBeDeleted);
            dbObject.SaveChanges();
            return Redirect("/Home/Index");
        }

        [AllowAnonymous]
        public ActionResult AboutUs()
        {
            return View();
        }
    }

    public class Student
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}