using AutoMapper;
using Domain.Entities;
using UseCase.UserServices.Services.DTOs;
using UseCase.Database;

namespace UseCase.UserServices.Services
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        public void RegistrateUser(RegistrateUserUseCaseDTO registrateUserDTO)
        {
            unitOfWork.StartTransaction();

            unitOfWork.UserRepository.Add(mapper.Map<User>(registrateUserDTO));

            unitOfWork.Commit();
        }

        public bool IsExistsByEmail(string email)
        {
            unitOfWork.StartTransaction();

            var isExists = unitOfWork.UserRepository.IsExistsByEmail(email);

            unitOfWork.Commit();

            return isExists;
        }

        public User GetByEmail(string email)
        {
            unitOfWork.StartTransaction();

            var user = unitOfWork.UserRepository.GetByEmail(email);

            Console.WriteLine(user.Id);

            unitOfWork.Commit();

            return user;
        }
    }
}
