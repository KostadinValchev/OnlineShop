using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Product
    {

        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Size { get; set; }

        public string Material { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
