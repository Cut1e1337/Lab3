using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
        public int TypeID { get; set; }
        public AppType AppType { get; set; }
        public decimal Price { get; set; }
    }
}
