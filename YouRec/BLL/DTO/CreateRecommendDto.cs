using BLL.DTO;
using DAL.Model;
using System.Collections.Generic;
using System.IO;

namespace YouRecWeb.Model
{
    public class CreateRecommendDto
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string RecommendText { get; set; }

        public string GroupName { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public int Rating { get; set; }

        IEnumerable<string> ImageLinks { get; set; }
    }
}
