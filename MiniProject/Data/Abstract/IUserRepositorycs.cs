using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
