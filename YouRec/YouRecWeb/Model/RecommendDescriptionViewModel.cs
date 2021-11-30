using DAL.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class RecommendDescriptionViewModel
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public int AuthorRating { get; set; }

        public string UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public string GroupName { get; set; }

        public ICollection<Image> ImageLinks { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public float AverageUserRating { get; set; }
    }
}
