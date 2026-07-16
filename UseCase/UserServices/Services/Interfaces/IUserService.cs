using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using UseCase.Database;
using UseCase.UserServices.Services.DTOs;

namespace UseCase.UserServices.Services.Interfaces
{
    public interface IUserService
    {
        public void RegistrateUser(RegistrateUserUseCaseDTO registrateUserDTO);
        public bool IsExistsByEmail(string email);
        public User GetByEmail(string email);
    }
}
