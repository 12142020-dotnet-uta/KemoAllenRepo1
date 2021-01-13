using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.ViewModels
{
    public class ProccessedOrderViewModel
    {
        public ProccessedOrderViewModel()
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
        public int Quantity { get; set; }

        //location
        [Required]
        [Display(Name = "Location")]
        public string LocationName { get; set; }

        //price
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}

