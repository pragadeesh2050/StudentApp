using StudentApp.DAL;
using StudentApp.Models;
using StudentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class InstructorController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: Instructor
        public ActionResult Index(int? id, int? courseID)
        {
            var viewModel = new InstructorIndexData();
            viewModel.Instructors = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.InstructorID = id.Value;
                viewModel.Courses = viewModel.Instructors.Where(
                    i => i.ID == id.Value).Single().Courses;
            }

            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(
                    x => x.CourseID == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        // GET: Instructors/Create
        [AllCourse]
        public ActionResult Create()
        {
            Instructor i = new Instructor();
            return View(i);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllCourse]
        public ActionResult Create(Instructor i)
        {
            var newCourses = i.Courses.Where(x=>x.CourseID > 0).Select(c => c.CourseID).ToArray();
            if(newCourses.Length > 0)
            {
                i.Courses = new List<Course>();
                List<Course> toAdd = db.Courses.Where(c => newCourses.Contains(c.CourseID)).Select(x => x).ToList<Course>();
                toAdd.ForEach(x => i.Courses.Add(x));
            }
            if (ModelState.IsValid)
            {
                db.Instructors.Add(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(i);
        }

        [AllCourse]
        public PartialViewResult CreateNewCourse()
        {
            Course course = new Course();
            return PartialView("~/Views/Shared/EditorTemplates/NewCourses.cshtml", course );
        }

        [AllCourse]
        public ActionResult Edit( int id )
        {
            Instructor i = db.Instructors.Find(id);
            return View(i);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllCourse]
        public ActionResult Edit( Instructor i)
        {
            return View(i);
        }        

    }

    public class AllCourseAttribute : FilterAttribute, IResultFilter
    {
        private SchoolContext db = new SchoolContext();
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Courses = new SelectList(db.Courses, "CourseID", "Title");
        }
    }
}