using AutoMapper;
using Domain.Entities;
using TaskManagerStart.DTOs.Project;
using TaskManagerStart.DTOs.User;
using UseCase.GeneralServices.DTOs;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.Services.DTOs;
using UseCase.ProjectTaskServices.MediatR.Commands;
using UseCase.ProjectTaskServices.Services.DTOs;
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
            CreateMap<FindProjectsInfoCommand, FindItemsDTO>();

            CreateMap<FilterProjectsDTO, FilterProjectsCommand>();
            CreateMap<FilterProjectsCommand, FilterItemsDTO>();

            CreateMap<GetPageDTO, GetPageProjectsInfoCommand>();

            CreateMap<SortProjectsDTO, SortProjectsInfoCommand>();
            CreateMap<SortProjectsInfoCommand, SortItemsDTO>();

            CreateMap<UpdateProjectDTO, UpdateProjectCommand>();
            CreateMap<UpdateProjectCommand, UpdateProjectUseCaseDTO>();
            CreateMap<UpdateProjectUseCaseDTO, Project>().ForAllMembers(opt =>
            {
                opt.Condition((src, desc, srcMember) => srcMember is not null);
            });

            CreateMap<Project, ShortProjectInfoDTO>();

            CreateMap<Project, LongProjectInfoDTO>();

            CreateMap<CreateProjectTaskCommand, CreateProjectTaskUseCaseDTO>();
            CreateMap<CreateProjectTaskUseCaseDTO, Project>();

            CreateMap<ChangeProjectTaskStatusCommand, ChangeProjectTaskStatusUseCaseDTO>();
            CreateMap<ChangeProjectTaskStatusUseCaseDTO, ProjectTask>();

            CreateMap<DeleteProjectTaskCommand, DeleteProjectTaskUseCaseDTO>();

            CreateMap<UpdateProjectTaskCommand, UpdateProjectTaskUseCaseDTO>();
            CreateMap<UpdateProjectTaskUseCaseDTO, ProjectTask>().ForAllMembers(opt =>
            {
                opt.Condition((src, desc, srcMember) => srcMember is not null);
            });

            CreateMap<FilterProjectTasksInfoCommand, FilterItemsDTO>();

            CreateMap<FindProjectTasksInfoCommand, FindItemsDTO>();

            CreateMap<SortProjectTasksInfoCommand, SortItemsDTO>();

            CreateMap<ProjectTask, ProjectTaskInfoDTO>();
        }
    }
}
