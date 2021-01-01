using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniProject.Data.Abstract;
using MiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Controllers
{
    public class ContactController : Controller
    {

        private IGenericRepository<Contact> _repository;

        public ContactController(IGenericRepository<Contact> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());

        }
    }
}