using StudentApp.DAL;
using StudentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class UserController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: User
        public ActionResult Create()
        {
            UserViewModel user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            if( ModelState.IsValid)
            {

            }
            return View(user);
        }

        public PartialViewResult AddNewBusiness(string Role)
        {
            BusinessRoleViewModel bvm = new BusinessRoleViewModel();
            bvm.Role = Role;
            //bvm.Businesses = new SelectList(db.Businesses, "ID", "Name");
            return PartialView("~/Views/Shared/EditorTemplates/NewBusiness.cshtml", bvm);
        }
    }
}