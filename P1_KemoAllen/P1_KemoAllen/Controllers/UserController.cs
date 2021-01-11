using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.ViewModels;
using BusinessLayer;
using Microsoft.Extensions.Logging;

namespace P1_KemoAllen.Controllers
{
    public class UserController : Controller
    {
        private StoreBusinessClass _businessLayer;
        private readonly ILogger<UserController> _logger;

        public UserController(StoreBusinessClass storeBusiness, ILogger<UserController> logger)
        {
            _businessLayer = storeBusiness;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("EditCustomer")]
        public ActionResult EditCustomer(Guid userId)
        {
            // call a method on BusinessLogic Layer that will take a playerId and return a PlayerView Model
            CustomerViewModel customerViewModel = _businessLayer.EditCustomer(userId);
            return View(customerViewModel);
        }

        [HttpPost]
        [ActionName("EditedCustomer")]
        public ActionResult EditedCustomer(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) { return View(customerViewModel); }

            //business logic
            CustomerViewModel customerViewModel1 = _businessLayer.EditedCustomer(customerViewModel);
            return View("DisplayCustomerDetails", customerViewModel1);
        }

        public IActionResult CustomersList()
        {
            //Get list from business layer
            List<CustomerViewModel> customerViewModelList = _businessLayer.CustomerList();

            return View(customerViewModelList);
        }

        [HttpGet]
        [ActionName("DisplayUserDetails")]
        public IActionResult DisplayCustomerDetails(Guid customerGuid)
        {
            //edit customer from business layer
            CustomerViewModel customerViewModel = _businessLayer.GetCustomer(customerGuid);

            //return view
            //Display user details
            return View();
        }

        [HttpDelete]
        [ActionName("DeletePlayer")]
        public IActionResult DeleteCustomer(Guid customerGuid)
        {
            //verify user exists. create model class in bl. create method in repolayer
            bool exists =_businessLayer.CheckUserExists(customerGuid);

            
            if(!exists)
            {
                ModelState.AddModelError("Failure", "We could not find that customer.");
                //check
                return View();
            }
            else
            {
                bool success = _businessLayer.DeleteCustomerById(customerGuid);
                if(success)
                {
                    //check
                    return RedirectToAction("CustomersList");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Unable to delete that player");
                    return View("Error");
                }
            }
        }


    }
}
