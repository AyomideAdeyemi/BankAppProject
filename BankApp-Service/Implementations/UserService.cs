using BankApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp_Service.Implementations
{
    public class UserService
    {
        User user = new User();
        public void EditUserInfo(string email, string phoneNumber)
        {
            user.Email = email;
            user.PhoneNumber = phoneNumber;
           
        }
    }
}
