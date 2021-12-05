using System.Collections;
using System.Collections.Generic;

namespace YouRecWeb.Model
{
    public class UserListViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public int TotalCount { get; set; }
    }
}
