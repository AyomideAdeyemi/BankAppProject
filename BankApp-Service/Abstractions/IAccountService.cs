using BankApp_Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp_Service.Abstractions
{
    public interface IAccountService
    {
        double GetBalance();
        bool Withdraw(double amount);
        bool Transfer(IAccountService toAccount, double amount);
        AccountType AccountType { get; set; }
    }
}
