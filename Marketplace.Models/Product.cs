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

        }

        public Product(string make, string model, int size, string material, decimal price, string description, int categoryId)
        {
            //this.Orders = new HashSet<Order>();
            this.Make = make;
            this.Model = model;
            this.Size = size;
            this.Material = material;
            this.Price = price;
            this.Description = description;
            this.CategoryId = categoryId;
            //this.Files = new List<File>();
            //this.Categories = new HashSet<Category>();

        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Size { get; set; }

        public string Material { get; set; }

        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

<<<<<<< HEAD
        

        //public virtual ICollection<Order> Orders { get; set; }

        //[ForeignKey("Buyer")]
        //public string BuyerId { get; set; }
        //public ApplicationUser Buyer { get; set; }

        //public virtual ICollection<File> Files { get; set; }
=======
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<File> Files { get; set; }
>>>>>>> 25a02aad657f2648bd15b299111104f200ff6995
    }
}
