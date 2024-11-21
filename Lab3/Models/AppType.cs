using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppType
    {
        [Key]
        public int TypeID { get; set; } 
        public string TypeName { get; set; }
        public ICollection<Pricing> Pricings { get; set; }
    }
}
