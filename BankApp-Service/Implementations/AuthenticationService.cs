//using BankApp_Models;
//using BankApp_Repository.Repository.UnitofWork.Abstraction;
//using BankApp_Service.Abstractions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BankApp_Service.Implementations

//{
//    public class AuthenticationService : IAuthenticationService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public AuthenticationService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<(User user, string error)> LoginUser(string email, string password)
//        {
//            if (email.IsEmailValid())
//            {
//                User user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
//                if (user is null || !password.CompareHash(user.PasswordSalt, user.Password))
//                {
//                    return (null, "Email or Password is incorrect");
//                }
//                return (user, string.Empty);
//            }
//            return (null, "Invalid email address");
//        }

//        public async Task<(bool status, string error)> RegisterUser(string email, string password)
//        {
//            if (email.IsEmailValid())
//            {
//                User userExist = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
//                if (userExist is null)
//                {
//                    var passwordDetails = password.GenerateHash();
//                    User user = new User() { Email = email, Password = passwordDetails[0], PasswordSalt = passwordDetails[1] };
//                    _unitOfWork.UserRepository.CreateUser(user);
//                    await _unitOfWork.SaveAsync();
//                    //_unitOfWork.Dispose();
//                    return (true, string.Empty);

//                }
//                else
//                {
//                    return (false, "User already exist");
//                }
//            }
//            else
//            {
//                return (false, "Invalid email format");
//            }

//        }
//    }
//}


