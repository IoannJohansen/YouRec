using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Recommend : BaseEntity
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public virtual int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Images> Images { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}