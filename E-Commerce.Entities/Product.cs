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
        public decimal Price { get; set; }
        public decimal Unit { get; set; }
        public decimal Weight { get; set; }
        public DateTime CreatedTime { get; set; }
        //public string latitude { get; set; }
        //public string longitude { get; set; }
        public List<Review> Reviews { get; set; }
        public virtual Category Category { get; set; }
    }
}
