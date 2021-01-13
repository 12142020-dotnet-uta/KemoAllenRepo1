using System;
using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModelLayer.ViewModels
{
    public class OrderViewModel //: PageModel
    {
        public OrderViewModel()
        {
        }

        //public string SessionKeyId = Guid.NewGuid().ToString();

        //Product
        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        //quantity
        //Convert to int
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        //location
        [Required]
        [Display(Name = "Location")]
        public string LocationName { get; set; }

        //price
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        //public void OnGet()
        //{
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyId)))
        //    {

        //    }
        //    var name = HttpContext.Session.GetString(SessionKeyId);
        //}
    }

    

    //public enum Location
    //{
    //    Walmart,
    //    Kroger
    //}

    //public enum Product
    //{
    //    Apple,
    //    Rice,
    //    Water,
    //    Milk
    //}

}
