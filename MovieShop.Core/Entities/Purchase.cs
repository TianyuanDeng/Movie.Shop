using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
    }
}
