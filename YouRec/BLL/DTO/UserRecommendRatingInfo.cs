using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserRecommendRatingInfo
    {
        public bool IsLiked { get; set; }

        public bool IsRated { get; set; }

        public int RatingValue { get; set; }
    }
}
