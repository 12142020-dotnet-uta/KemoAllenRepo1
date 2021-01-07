using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.ViewModels;
using BusinessLayer;

namespace P1_KemoAllen.Controllers
{
    public class UserController : Controller
    {
        private readonly StoreBusinessClass _businessLayer;

        public UserController()
        {

        }

        public IActionResult CustomerList()
        {
            //Get list from business layer
            
        }

        [HttpGet]
        [ActionName("UserDetails")]
        public IActionResult CustomerDetails(Guid customerGuid)
        {
            //edit player from business layer

            //return view

        }

        [HttpDelete]
        [ActionName("DeletePlayer")]
        public IActionResult DeleteCustomer(Guid customerGuid)
        {
            //verify user exists. create model class in bl. create method in repolayer

            //
        }

    }
}
