using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UpdateRecommendDto
    {
        public int RecommendId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int AuthorRating { get; set; }

        public string UserId { get; set; }

        public int GroupId { get; set; }

        public ICollection<string> ImageLinks { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
