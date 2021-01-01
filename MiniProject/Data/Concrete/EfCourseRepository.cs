using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class EfCourseRepository : ICourseRepository
    {


        private DataContext context;

        public EfCourseRepository(DataContext _context)
        {
            context = _context;
        }

        public IEnumerable<Request> Requests => context.Requests;

        public IQueryable<Course> Courses => context.Courses;

        public int CreateCourse(Course newCourse)
        {
            context.Courses.Add(newCourse);
            context.SaveChanges();

            return newCourse.Id;
        }

        public void DeleteCourse(int courseid)
        {
            var entity = GetById(courseid);

            context.Courses.Remove(entity);

            if (entity.Instructor != null)
            {
                context.Remove(entity.Instructor);
            }
            context.SaveChanges();

        }

        public Course GetById(int courseid)
        {
            return context.Courses
                  .Include(i => i.Instructor)
                  .ThenInclude(i => i.Contact)
                  .ThenInclude(i => i.Address)
                  .FirstOrDefault(i => i.Id == courseid);
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByActive(bool IsActive)
        {
            return context.Courses.Where(i => i.IsActive == IsActive).ToList();
        }

        public IEnumerable<Course> GetCoursesByFilters(string name = null, decimal? price = null, string isActive = null)
        {

            IQueryable<Course> query = context.Courses;


            if (name != null)
            {
                query = query.Where(i => i.Name.ToLower().Contains(name.ToLower()));

            }

            if (price != null)
            {
                query = query.Where(i => i.price >= price);
            }

            if (isActive == "on")
            {
                query = query.Where(i => i.IsActive == true);
            }

            return query.Include(i => i.Instructor).ToList();

        }




        public void UpdateAll(int Id, Course[] courses)
        {
            context.Courses.UpdateRange(courses.Where(i => i.InstructorId != Id));
            context.SaveChanges();
        }




        public void UpdateCourse(Course updatedCourse, Course originalCourse = null)
        {
            if (originalCourse == null)
            {
                originalCourse = context.Courses.Find(updatedCourse.Id);
            }
            else
            {
                context.Courses.Attach(originalCourse);
            }

            originalCourse.Name = updatedCourse.Name;
            originalCourse.Description = updatedCourse.Description;
            originalCourse.price = updatedCourse.price;
            originalCourse.IsActive = updatedCourse.IsActive;

            originalCourse.Instructor.Name = updatedCourse.Instructor.Name;

            context.SaveChanges();
        }
    }
}

