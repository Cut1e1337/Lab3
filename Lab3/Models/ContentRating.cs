using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Models
{
    public class ContentRating
    {
        public int ContentRatingID { get; set; }
        public string RatingName { get; set; }
        public ICollection<Application> Applications { get; set; } // Зв'язок з додатками
    }
}
