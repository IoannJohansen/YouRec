using DAL.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Rating : BaseEntity
    {
        public int UserId { get; set; }

        [Range(0, 10)]
        public int Rate{ get; set; }

        public int RecommendId { get; set; }

        public virtual Recommend Recommend { get; set; }
    }
}
