using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class CourseController : Controller
    {

        private ICourseRepository repository;

        public CourseController(ICourseRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index(string name = null, decimal? price = null, string isActive = null)

        {
            var courses = repository.GetCoursesByFilters(name, price, isActive);
            ViewBag.Name = name;
            ViewBag.Price = price;
            ViewBag.isActive = isActive == "on" ? true : false;

            return View(courses);
        }

        public IActionResult Edit(int Id)
        {
            ViewBag.ActionMode = "Edit";
            return View(repository.GetById(Id));
        }
        [HttpPost]
        public IActionResult Edit(Course entity, Course original)
        {
            repository.UpdateCourse(entity, original);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View("Edit", new Course());
        }

        [HttpPost]
        public IActionResult Create(Course newCourse)
        {
            int id = repository.CreateCourse(newCourse);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            repository.DeleteCourse(Id);
            return RedirectToAction("Index");
        }
    }
}