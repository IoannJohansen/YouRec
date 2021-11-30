using DAL.Model.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Rating : BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        [Range(0, 5)]
        public int Rate{ get; set; }

        public int RecommendId { get; set; }
        
        [JsonIgnore]
        public Recommend Recommend { get; set; }
        
        [JsonIgnore]
        public AppUser User { get; set; }
    }
}
