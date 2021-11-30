using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PaginatedObjectDto<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }

        public int ItemCount { get; set; }
    }
}
