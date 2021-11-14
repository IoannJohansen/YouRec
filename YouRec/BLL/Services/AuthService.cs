using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        public Task<IActionResult> IsSignedIn()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SignIn()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> SignUp()
        {
            throw new NotImplementedException();
        }
    }
}
