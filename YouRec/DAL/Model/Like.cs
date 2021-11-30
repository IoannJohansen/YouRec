using DAL.Model.Base;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace DAL.Model
{
    public class Like : BaseEntity
    {
        public string UserId { get; set; }

        public int RecommendId { get; set; }

        [JsonIgnore]
        public AppUser User { get; set; }

        [JsonIgnore]
        public Recommend Recommend { get; set; }
    }
}
