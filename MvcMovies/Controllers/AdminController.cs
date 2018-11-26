using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovies.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminLink()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        
        }

        public ActionResult AssignRole()
        {
            return View();
        }

    }
}