using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class MyRecommendsPaged
    {
        public IEnumerable<RecommendViewModel> Recommends { get; set; }

        public int maxCount { get; set; }
    }
}
