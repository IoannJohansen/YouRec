using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DAL.Model.Base;

namespace DAL.Model
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }

        [JsonIgnore]
        public ICollection<Recommend> Recommends { get; set; }
    }
}
