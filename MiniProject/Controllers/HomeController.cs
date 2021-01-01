using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class HomeController : Controller
    {

        private DataContext context;

        public HomeController(DataContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(Request model)

        {
            context.Requests.Add(model);
            context.SaveChanges();

            return View("Thanks", model);
        }


        public IActionResult List()
        {
            return View(context.Requests.OrderBy(i => i.Name));
        }

    }
}







//// controller model classlarindan verileri alacak ve viewya aktaracak
//public class HomeController : Controller
//{
//    public IActionResult Index() //index userine gelip sag tikladik ve sonra view olusturduk
//                                 //ama tabiki view klasoru > icinde home klasoru > icinde index adinda bir view olusturduk
//                                 //eger view klasoru icinde olusturmak isteyorsak home klasorunu unutmayalim
//    {
//        //1 model kalsorun icindeki request clasaina ulasmak icin MiniProject.Models.Request yazdik
//        //2 sonra model = new Models.Request(); dedik yani yeni model olusturduk


//        //3 modele alanlarina ulasmak icin bunlari kulladik

//        return View();  // dikkat buradan model vrilerini VEIWLARA ya gonderiyoruz ve hangi viewlarda gorunmesini..
//                             //isteyorsak o viewda verileri karsiliyoruz
//                             //yani karsilama kodu yaziyoruz
//    }
//}