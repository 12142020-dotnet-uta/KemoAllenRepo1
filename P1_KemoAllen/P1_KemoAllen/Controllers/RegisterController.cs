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
    public class RegisterController : Controller
    {
        private StoreBusinessClass _businessLayer;
        private readonly ILogger<UserController> _logger;

        public RegisterController(StoreBusinessClass storeBusiness, ILogger<UserController> logger)
        {
            _businessLayer = storeBusiness;
            _logger = logger;
        }

        public ActionResult Register()
        {
            return View();
        }

        [ActionName("RegisterCustomer")]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (registerViewModel is null)
            {
                throw new ArgumentNullException(nameof(registerViewModel));
            }
            //Add new customer
            CustomerViewModel customerViewModel = _businessLayer.RegisterCustomer(registerViewModel);

            return View("DisplayCustomerDetails", customerViewModel);
        }

     
    }
}
