using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MyHandlerLibrary
{
    public class MyHandlerLibrary : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Some output from myhandler");
        }
    }
}
