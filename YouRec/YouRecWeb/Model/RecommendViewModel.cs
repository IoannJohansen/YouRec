using DAL.Model;
using System;
using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class RecommendViewModel
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public ICollection<Image> Images { get; set; }

        public DateTime CreationDate { get; set; }

        public string Group { get; set; }

        public string AuthorName { get; set; }

        public int AverageUserRating { get; set; }
    }
}
