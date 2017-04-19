using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class OrderViewModel
    {
        public string ShippingAddress { get; set; }


        public string Fullname { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        //public virtual ICollection<Product> Products { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
