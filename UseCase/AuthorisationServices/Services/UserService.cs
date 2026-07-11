using AutoMapper;
using Domain.Entities;
using UseCase.AuthorisationServices.Services.DTOs;
using UseCase.Database;

namespace UseCase.AuthorisationServices.Services
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        public void RegistrateUser(RegistrateUserDTO registrateUserDTO)
        {
            unitOfWork.UserRepository.Add(mapper.Map<User>(registrateUserDTO));
        }

        public bool IsExistsByEmail(string email)
        {
            return unitOfWork.UserRepository.IsExistsByEmail(email);
        }

        public User GetByEmail(string email)
        {
            return unitOfWork.UserRepository.GetByEmail(email);
        }
    }
}
