using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Installation
    {
        public int InstallationID { get; set; }
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
        public string Installs { get; set; }
    }
}
