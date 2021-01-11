using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1_KemoAllen.Controllers
{
    public class OrderController : Controller
    {
        private StoreBusinessClass _businessLayer;
        private readonly ILogger<UserController> _logger;

        public ActionResult Order()
        {
            return View();
        }

        [ActionName("MakeOrder")]
        public ActionResult Order(OrderViewModel orderViewModel)
        {

            return View();
        }

        
    }
}
