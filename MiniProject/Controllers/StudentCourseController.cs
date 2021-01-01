using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class StudentCourseController : Controller
    {

        private DataContext _context;

        public StudentCourseController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var model = new StudentCourseModel();

            model.Courses = _context.Courses.Include(i => i.StudentCourses).ThenInclude(i => i.Student).ToList();
            model.Students = _context.Students.Include(i => i.StudentCourses).ThenInclude(i => i.Course).ToList();

            return View(model);
        }


        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            ViewBag.Courses = _context.Courses.Include(p => p.StudentCourses);
            return View("StudentEditor", _context.Students.Find(id));
        }

        [HttpPost]
        public IActionResult EditStudent(int id, int[] courseid)
        {
            Student student = _context.Students.Include(s => s.StudentCourses).First(s => s.Id == id);

            if (student != null)
            {
                student.StudentCourses = courseid.Select(pid => new StudentCourse { StudentId = id, CourseId = pid }).ToList();
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}