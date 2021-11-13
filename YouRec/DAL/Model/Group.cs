using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }

        public virtual Recommend Recommend { get; set; }
    }
}
