using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class PurchaseRequestModel
    {
        [Required]
        public int userId { get; set; }
        public string purchaseNumber { get; set; }
        public double totalPrice { get; set; }
        public DateTime pruchaseDateTime { get; set; }
        public int movieId { get; set; }
    }
}
