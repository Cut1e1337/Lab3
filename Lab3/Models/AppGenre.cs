using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppGenre
    {
        public int AppGenreID { get; set; }
        public int ApplicationID { get; set; }
        public Application Application { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
