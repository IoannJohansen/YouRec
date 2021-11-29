﻿using BLL.DTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRecommendService
    {
        Task<IEnumerable<Recommend>> GetRecentlyUploaded();
        Task<IEnumerable<Recommend>> GetMostRated();
        Task<Recommend> GetBaseRecommendDescription(int recommendId);
        Task<Recommend> GetFullRecommendDescription(int recommendId);
    }
}
