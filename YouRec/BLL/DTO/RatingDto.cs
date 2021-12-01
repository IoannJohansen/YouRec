using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RatingDto
    {
        public string Userid { get; set; }

        public int RecommendId { get; set; }

        public int Rate { get; set; }
    }
}
