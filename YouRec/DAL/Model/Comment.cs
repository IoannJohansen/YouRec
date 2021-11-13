using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Comment : BaseEntity
    {
        public int RecommendId { get; set; }

        public string CommentMessage { get; set; }

        public virtual Recommend Recommend { get; set; }
    }
}
