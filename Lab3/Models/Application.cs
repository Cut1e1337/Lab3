using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int ContentRatingID { get; set; }
        public ContentRating ContentRating { get; set; }
        public DateTime LastUpdate { get; set; }
        public string CurrentVersion { get; set; }
        public string MinAndroidVersion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Installation> Installations { get; set; }
        public ICollection<Pricing> Pricings { get; set; }
        public ICollection<AppGenre> AppGenres { get; set; }

        public ICollection<AppType> AppTypes { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
