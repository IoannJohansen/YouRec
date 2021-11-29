using DAL.Model.Base;
using System.Text.Json.Serialization;

namespace DAL.Model
{
    public class Image : BaseEntity
    {
        public string Original { get; set; }

        public int RecommendId { get; set; }
        
        [JsonIgnore]
        public Recommend Recommend { get; set; }
    }
}
