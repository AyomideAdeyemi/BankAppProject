using BankApp_Repository.Repository.UnitofWork.Abstraction;
using BankApp_Service.Abstractions;

namespace BankApp_Service.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(bool status, string error)> UpdateUserInformation(int Id, string firstName, string lastName, string email, string phoneNumber)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(Id);
            if (user == null)
            {
                return (false, "User not found.");
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.PhoneNumber = phoneNumber;

            _unitOfWork.UserRepository.UpdateUser(user);
            await _unitOfWork.SaveAsync();

            return (true, "User information updated successfully.");
        }


    }



}


