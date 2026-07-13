using AutoMapper;
using Domain.Entities;
using TaskManagerStart.DTOs.Project;
using TaskManagerStart.DTOs.User;
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

            CreateMap<CreateProjectDTO, CreateProjectCommand>();
            CreateMap<CreateProjectCommand, CreateProjectUseCaseDTO>();
            CreateMap<CreateProjectUseCaseDTO, Project>();

            CreateMap<DeleteProjectDTO, DeleteProjectCommand>();  
            CreateMap<DeleteProjectCommand, DeleteProjectUseCaseDTO>();

            CreateMap<FindProjectsDTO, FindProjectsInfoCommand>();
            CreateMap<FindProjectsInfoCommand, FindProjectsUseCaseDTO>();

            CreateMap<FilterProjectsDTO, FilterProjectsCommand>();
            CreateMap<FilterProjectsCommand, FilterProjectsUseCaseDTO>();

            CreateMap<SortProjectsDTO, SortProjectsInfoCommand>();
            CreateMap<SortProjectsInfoCommand, SortProjectsUseCaseDTO>();

            CreateMap<UpdateProjectCommand, UpdateProjectDTO>();
            CreateMap<UpdateProjectDTO, Project>().ForAllMembers(opt =>
            {
                opt.Condition((src, desc, srcMember) => srcMember is not null);
            });

            CreateMap<Project, ShortProjectInfoDTO>();

            CreateMap<Project, LongProjectInfoDTO>();
        }
    }
}
