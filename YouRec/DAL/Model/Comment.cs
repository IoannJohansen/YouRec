using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.Base;

namespace DAL.Model
{
    public class Comment : BaseEntity
    {
        public string CommentMessage { get; set; }

        public int RecommendId { get; set; }

        public virtual Recommend Recommend { get; set; }
    }
}
