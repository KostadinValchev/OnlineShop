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
            //this.Files = new HashSet<File>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }

        //public ICollection<File> Files { get; set; }
    }
}
