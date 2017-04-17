using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [StringLength(140)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
