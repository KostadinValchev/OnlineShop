using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int PrdouctId { get; set; }

        public virtual Product Product { get; set; }
    }
}
