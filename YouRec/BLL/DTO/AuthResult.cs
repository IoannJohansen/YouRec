using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AuthResult
    {
        public bool Success { get; set; }

        public bool IsAdmin { get; set; }

        public string Username { get; set; }
    }
}
