using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.Base;

namespace DAL.Model
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }

        public virtual ICollection<Recommend> Recommends { get; set; }
    }
}
