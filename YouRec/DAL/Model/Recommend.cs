using DAL.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Recommend : BaseEntity
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }

        [Range(0, 10)]
        public int AuthorRating { get; set; }

        public DateTime CreationDate { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<RecommendTag> RecommendTags { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Like> Likes { get; set; }

        public AppUser User { get; set; }
    }
}