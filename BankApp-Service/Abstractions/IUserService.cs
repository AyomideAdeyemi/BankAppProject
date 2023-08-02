using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp_Service.Abstractions
{
    public interface IUserService
    {
        Task<(bool status, string error)> UpdateUserInformation(int Id, string firstName, string lastName, string email, string phoneNumber);
    }
}
