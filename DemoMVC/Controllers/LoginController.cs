using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoMVC.Models;
using System.Web.Security;
using DemoMVC.Helpers;

namespace DemoMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            //return View("SignIn");
            return View();
        }

        public ActionResult AfterSignIn(AppUser user, string ReturnUrl)
        {
            if (CheckUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                string loginDetails = string.Format("{0} has logged in.", user.UserName); //User.Identity.Name);
                Logger.CurrentLogger.Log(loginDetails);

                if (ReturnUrl!=null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return Redirect("/home/index");
                }
            }
            else
            {
                return View("SignIn");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/home/index");
        }

        private bool CheckUser(AppUser user)
        {
            //you will do the db check 
            //you = sunbeam dac pune students
            return (user.UserName == "abc" && user.Password == "abc@123");
        }
    }
}