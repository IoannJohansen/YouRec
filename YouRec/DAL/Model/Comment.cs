using DAL.Model.Base;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace DAL.Model
{
    public class Comment : BaseEntity
    {
        public string CommentMessage { get; set; }

        public string UserId { get; set; }

        public int RecommendId { get; set; }

        [JsonIgnore]
        public Recommend Recommend { get; set; }

        public IdentityUser User { get; set; }
    }
}
