﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DAL.Model.Base;

namespace DAL.Model
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }


        public int RecommendId { get; set; }
        [JsonIgnore]
        public Recommend Recommend{ get; set; }
    }
}
