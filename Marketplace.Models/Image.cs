using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{

    public class Image
    {

        public Image()
        {
            this.Products = new HashSet<Product>();
            this.Category = new HashSet<Category>();
        }

        public int Id { get; set; }


        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }


        public byte[] Content { get; set; }


        public FileType FileType { get; set; }


        public virtual ICollection<Product> Products { get; set; }


        public virtual ICollection<Category> Category { get; set; }
    }
    public enum FileType
    {
        Avatar = 1, Photo
    }
}
