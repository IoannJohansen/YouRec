using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class RecommendListViewModel
    {
        public int CurrentCount { get; set; }

        public IEnumerable<RecommendViewModel> Recommends { get; set; }
    }
}
