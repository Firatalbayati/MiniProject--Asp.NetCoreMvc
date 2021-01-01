using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class SeedDatabase
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is DataContext)
                {

                    DataContext _context = context as DataContext;

                    if (_context.Courses.Count() == 0)
                    {
                        _context.Courses.AddRange(Courses);
                    }


                    if (_context.Instructors.Count() == 0)
                    {
                        _context.Instructors.AddRange(Instructors);
                    }


                    if (_context.Students.Count() == 0)
                    {
                        _context.Students.AddRange(Students);
                    }
                }


                if (context is UserContext)
                {
                    UserContext _context = context as UserContext;

                    if (_context.Users.Count() == 0)
                    {
                        _context.Users.AddRange(Users);
                    }
                }

                context.SaveChanges();
            }
        }

        private static Course[] Courses
        {
            get
            {
                Course[] courses = new Course[]
                {
                    new Course() { Name = "Html", price = 10, Description = "about html", IsActive = true, Instructor=Instructors[0] },// SIFIRINCI ELEMAN
                    new Course() { Name = "Css", price = 10, Description = "about Css", IsActive = true, Instructor=Instructors[1] },
                    new Course() { Name = "Javascipt", price = 20, Description = "about Javascipt", IsActive = false, Instructor=Instructors[2] },
                    new Course() { Name = "NodeJs", price = 10, Description = "about NodeJs", IsActive = true, Instructor=Instructors[3] },
                    new Course() { Name = "Angular", price = 30, Description = "about Angular", IsActive = false , Instructor=Instructors[0]},
                    new Course() { Name = "React", price = 20, Description = "about React", IsActive = false , Instructor=Instructors[1] },
                    new Course() { Name = "Mvc", price = 10, Description = "about Mvc", IsActive = false , Instructor=Instructors[2] }
                };
                return courses;
            }
        }

        private static Student[] Students
        {
            get
            {
                Student[] students = new Student[]
                {
                    new Student() { Name = "Student 1"},
                    new Student() { Name = "Student 2"},
                    new Student() { Name = "Student 3"},
                    new Student() { Name = "Student 4"}
                };
                return students;
            }
        }

        private static Instructor[] Instructors = {
            new Instructor(){  Name="Ahmet", Contact=new Contact(){  Email="ahmet@gmail.com", Phone="1213132", Address=new Address(){  City="Kocaeli", Country="Türkiye", Text="Atatürk cad.No:45"} } },
            new Instructor(){  Name="Mehmet", Contact=new Contact(){  Email="mehmet@gmail.com", Phone="1213132", Address=new Address(){  City="İstabul", Country="Türkiye", Text="Atatürk cad.No:45"} } },
            new Instructor(){  Name="Ali", Contact=new Contact(){  Email="ali@gmail.com", Phone="1213132", Address=new Address(){  City="Adana", Country="Türkiye", Text="Atatürk cad.No:45"} } },
            new Instructor(){  Name="Hasan"}
        };
        private static User[] Users = {

            new User(){ Username="firatalbayati", Email="firatalbayati@gmail.com", Password="123456", City="istanbul"},
            new User(){ Username="vatanalbayati", Email="vatanalbayati@gmail.com", Password="123456", City="Kocaeli"},
            new User(){ Username="omeralbayati", Email="omeralbayati@gmail.com", Password="123456", City="İstanbul"},
        };
    }
}
