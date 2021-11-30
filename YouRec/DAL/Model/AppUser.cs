using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DAL.Model
{
    public class AppUser : IdentityUser
    {
        public int? ImageId { get; set; }

        [JsonIgnore]
        public ICollection<Like> Likes { get; set; }

        [JsonIgnore]
        public Image Image { get; set; }
    }
}
