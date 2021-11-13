using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Tag : BaseEntity
    {
        public int RecommendId { get; set; }

        public string TagName { get; set; }

        public virtual Recommend Recommend{ get; set; }
    }
}
