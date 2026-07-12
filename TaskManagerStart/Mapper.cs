using AutoMapper;
using Domain.Entities;
using TaskManagerStart.DTOs;
using UseCase.UserServices.MediatR.Commands;
using UseCase.UserServices.Services.DTOs;

namespace TaskManagerStart
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<RegistrateUserDTO, RegistrateUserCommand>();
            CreateMap<RegistrateUserCommand, CreatePasswordHashDTO>();
            CreateMap<RegistrateUserCommand, RegistrateUserUseCaseDTO>();
            CreateMap<RegistrateUserUseCaseDTO, User>();

            CreateMap<User, UserInfoDTO>();

            CreateMap<VerifyUserDTO, VerifyUserCommand>();
            CreateMap<VerifyUserCommand, VerifyPasswordDTO>();
        }
    }
}
