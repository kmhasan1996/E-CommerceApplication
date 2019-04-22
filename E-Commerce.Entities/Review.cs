using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class Review
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public decimal RatingPoint { get; set; }
        public string ReviewMessage { get; set; }
        public virtual Product Product { get; set; }


    }
}
