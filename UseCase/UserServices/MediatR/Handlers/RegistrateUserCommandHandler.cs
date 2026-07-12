using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using MediatR;
using UseCase.UserServices.MediatR.Commands;
using UseCase.UserServices.MediatR.Responces;
using UseCase.UserServices.Services;
using UseCase.UserServices.Services.DTOs;
using UseCase.Database;

namespace UseCase.UserServices.MediatR.Handlers
{
    
    public class RegistrateUserCommandHandler(IMapper mapper, UserService userService, JwtService jwtService,
        CryptService cryptService) : IRequestHandler<RegistrateUserCommand, RegistrateUserResponce>
    {
        public Task<RegistrateUserResponce> Handle(RegistrateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = cryptService.CreatePasswordHash(mapper.Map<CreatePasswordHashDTO>(request));

            var registrateUserDTO = mapper.Map<RegistrateUserUseCaseDTO>(request);
            registrateUserDTO.PasswordHash = passwordHash;

            userService.RegistrateUser(registrateUserDTO);

            var userInfo = mapper.Map<UserInfoDTO>(userService.GetByEmail(registrateUserDTO.Email));

            var generateJwtDTO = new GenerateJwtDTO { UserId = userInfo.Id };

            JwtSecurityToken jwt = jwtService.GenerateJwtTokent(generateJwtDTO);

            var responce = new RegistrateUserResponce { JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt) };

            return Task.FromResult(responce);
        }
    }
}
