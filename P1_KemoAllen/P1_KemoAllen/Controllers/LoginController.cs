using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer;
using ModelLayer.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P1_KemoAllen.Controllers
{
    public class LoginController : Controller
    {
        private StoreBusinessClass _businessLayer;
        private readonly ILogger<UserController> _logger;

        public LoginController(StoreBusinessClass storeBusiness, ILogger<UserController> logger)
        {
            _businessLayer = storeBusiness;
            _logger = logger;
        }

        public ActionResult Login()
        {
            return View();
        }

        [ActionName("LoginCustomer")]
        public ActionResult Login(LoginViewModel logInViewModel)
        {
            //Dependancy Injection
            CustomerViewModel customerViewModel = _businessLayer.LoginCustomer(logInViewModel);

            return View("DisplayCustomerDetails", customerViewModel);
        }

        [ActionName("LogoutCustomer")]
        public ActionResult Logout()
        {
            //clear session data
            return View("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }//
}//
