using BankApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp_Service.Abstractions
{
    public interface IAuthenticationService
    {
       
            Task<(User user, string error)> LoginUser(string email, string password);
            Task<(bool status, string error)> RegisterUser(string email, string password);

        
    }
}
