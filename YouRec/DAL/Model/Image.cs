using DAL.Model.Base;
using System.Text.Json.Serialization;

namespace DAL.Model
{
    public class Image : BaseEntity
    {
        public string Link { get; set; }

        public int RecommendId { get; set; }
        [JsonIgnore]
        public Recommend Recommend { get; set; }
    }
}
