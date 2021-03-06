﻿using System;
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

        public int Id { get; set; }

        public string ShippingAddress { get; set; }
        
        public string Fullname { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        //public virtual ICollection<Product> Products { get; set; }

    }
}
