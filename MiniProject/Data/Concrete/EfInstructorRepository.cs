using Microsoft.EntityFrameworkCore;
using MiniProject.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class EfInstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {


        private DataContext _context;

        public EfInstructorRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Instructor> GetTopInstructor()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Instructor> GetAll()
        {
            _context.Courses.Where(i => i.Instructor != null).Load();
            return _context.Instructors;
        }
    }
}
