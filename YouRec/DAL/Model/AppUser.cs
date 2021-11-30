using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AppUser : IdentityUser
    {
        [JsonIgnore]
        public ICollection<Like> Likes { get; set; }
    }
}
