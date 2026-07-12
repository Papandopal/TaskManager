using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using MediatR;
using UseCase.AuthorisationServices.MediatR.Commands;
using UseCase.AuthorisationServices.MediatR.Responces;
using UseCase.AuthorisationServices.Services;
using UseCase.AuthorisationServices.Services.DTOs;

namespace UseCase.AuthorisationServices.MediatR.Handlers
{
    public class VerifyUserService(IMapper mapper, UserService userService, CryptService cryptService, JwtService jwtService) : IRequestHandler<VerifyUserCommand, VerifyUserResponce>
    {
        public Task<VerifyUserResponce> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
        {
            var userInfo = mapper.Map<UserInfoDTO>(userService.GetByEmail(request.Email));

            var verifyUserDTO = mapper.Map<VerifyPasswordDTO>(request);

            verifyUserDTO.Hash = userInfo.PasswordHash;

            bool verify = cryptService.VerifyPassword(verifyUserDTO);

            if (!verify) throw new Exception("Verify failed");

            var generateJwtDTO = new GenerateJwtDTO { UserId =  userInfo.Id };

            JwtSecurityToken jwt = jwtService.GenerateJwtTokent(generateJwtDTO); 

            var responce = new VerifyUserResponce { JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt)};

            return Task.FromResult(responce);
        }
    }
}
