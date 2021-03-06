using BLL.DTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouRecWeb.Model;

namespace BLL.Interfaces
{
    public interface IRecommendService
    {
        Task<IEnumerable<Recommend>> GetRecentlyUploaded();
        Task<IEnumerable<Recommend>> GetMostRated();
        Task<Recommend> GetRecommendDescription(int recommendId);
        Task<Recommend> CreateNewRecommend(CreateRecommendDto createRecommendDto);
        Task<(IEnumerable<Recommend>,int)> GetSorted(RecommendsSorteddDto sortDto);
        Task<(IEnumerable<Recommend>,int)> GetForUserId(RecommendsSorteddDto sortDto);
        Task DeleteById(int id);
        Task<Recommend> GetByID(int id);
        Task<Recommend> UpdateRecommendInfo(UpdateRecommendDto recommend);
        Task UpdateImages(UpdateRecommendDto updateRecommendDto);
        Task<IEnumerable<Recommend>> GetfromFulltexted(string query);
    }
}
