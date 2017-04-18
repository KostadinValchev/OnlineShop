using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class ProductViewModel
    {
        
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Size { get; set; }

        public string Material { get; set; }

        public decimal Price { get; set; }

        //public byte[] Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        
        public int CategoryId { get; set; }
        
        //public virtual ICollection<File> Files { get; set; }
    }
}
