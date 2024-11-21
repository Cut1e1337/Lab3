using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}
