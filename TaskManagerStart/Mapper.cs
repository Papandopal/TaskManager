using AutoMapper;
using Domain.Entities;
using TaskManagerStart.DTOs;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.Services.DTOs;
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

            CreateMap<CreateProjectCommand, CreateProjectUseCaseDTO>();
            CreateMap<CreateProjectUseCaseDTO, Project>();

            CreateMap<FindProjectsInfoCommand, FindProjectsDTO>();

            CreateMap<Project, ShortProjectInfoDTO>();

            CreateMap<Project, LongProjectInfoDTO>();

            CreateMap<GetProjectsInfoByFilterCommand, FilterProjectsDTO>();

            CreateMap<SortProjectsInfoCommand, SortProjectsDTO>();

            CreateMap<UpdateProjectCommand, UpdateProjectUseCaseDTO>();
            CreateMap<UpdateProjectUseCaseDTO, Project>().ForAllMembers(opt =>
            {
                opt.Condition((src, desc, srcMember) => srcMember is not null);
            });
        }
    }
}
