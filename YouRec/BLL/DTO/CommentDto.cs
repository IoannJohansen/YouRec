﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CommentDto
    {
        public string UserId { get; set; }

        public int RecommendId { get; set; }

        public string CommentMessage { get; set; }
    }
}
