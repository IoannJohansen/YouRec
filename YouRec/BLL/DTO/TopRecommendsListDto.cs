using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TopRecommendsListDto
    {
        public const int PageSize = 10;

        public int CurrentCount { get; set; }

        public IEnumerable<Recommend> Recommends { get; set; }
    }
}
