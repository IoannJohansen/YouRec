using DAL.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class RecommendTag : BaseEntity
    {
        public int TagId { get; set; }

        public int RecommendId { get; set; }

        [JsonIgnore]
        public Tag Tag { get; set; }
        
        [JsonIgnore]
        public Recommend Recommend { get; set; }
    }
}
