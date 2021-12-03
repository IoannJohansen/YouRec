using DAL.Model;
using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class CreateRecommendDto
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string RecommendText { get; set; }

        public int GroupId { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public int Rating { get; set; }

        public IEnumerable<string> ImageLinks { get; set; }
    }
}
