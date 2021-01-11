using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
        }

        //Product
        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        //quantity
        //Convert to int
        [Required]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }

        //location
        [Required]
        [Display(Name = "Location")]
        public string LocationName { get; set; }

        //price
    }
}
