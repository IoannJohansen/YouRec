using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class RecommendListViewModel
    {
        public IEnumerable<RecommendViewModel> RecommendList { get; set; }

        public int CurrentCount { get; set; }
    }
}
