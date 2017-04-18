using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public enum Status
    {
        Pending,
        Processing,
        Shipped
    }
    public class Order
    {
        public Order()
        {
            //this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string ShippingAddress { get; set; }

        public string BillingAddress { get; set; }

        public decimal Ammount { get; set; }

        public Status Status { get; set; }
        
        //public virtual ICollection<Product> Products { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
