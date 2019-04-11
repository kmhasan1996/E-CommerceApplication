using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities
{
    public class FoodandMedicine
    {
        public int ID { get; set; }
        public string Month { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public string Food { get; set; }
        public string Medicine { get; set; }
        public virtual Category Category { get; set; }

    }
}
