using AutoMapper;
using Domain.Entities;
using UseCase.AuthorisationServices.MediatR.Commands;

namespace TaskManagerStart
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<RegistrateUserCommand, User>();
        }
    }
}
