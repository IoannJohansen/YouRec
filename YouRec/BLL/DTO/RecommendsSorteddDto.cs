using BLL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RecommendsSorteddDto
    {
        public string UserId { get; set; }

        public SortMode SortMode { get; set; }

        public SortOrder SortOrder { get; set; }

        public int PageNumber { get; set; }

        public int Amount { get; set; }
    }
}
