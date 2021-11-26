using DAL.Model.Base;

namespace DAL.Model
{
    public class Image : BaseEntity
    {
        public string Link { get; set; }

        public int RecommendId { get; set; }

        public virtual Recommend Recommend { get; set; }
    }
}
