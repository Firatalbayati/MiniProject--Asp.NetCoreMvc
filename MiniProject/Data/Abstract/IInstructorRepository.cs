using MiniProject.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{

    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        IEnumerable<Instructor> GetTopInstructor();
    }
}
