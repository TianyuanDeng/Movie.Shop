using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class PurchaseRequestModel
    {
        public int userId { get; set; }
        public Guid purchaseNumber { get; set; }
        public decimal? totalPrice { get; set; }
        public DateTime purchaseDateTime { get; set; }
        public int movieId { get; set; }
    }
}
