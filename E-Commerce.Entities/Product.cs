using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ImageURL2 { get; set; }
        public string ImageURL3 { get; set; }
        public string ImageURL4 { get; set; }
        public decimal Price { get; set; }
        public decimal Unit { get; set; }
        public decimal Weight { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<Review> Reviews { get; set; }
        public virtual Category Category { get; set; }
    }
}
