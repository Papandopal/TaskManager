using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using MediatR;
using UseCase.UserServices.MediatR.Commands;
using UseCase.UserServices.MediatR.Responces;
using UseCase.UserServices.Services.Interfaces;
using UseCase.UserServices.Services.DTOs;

namespace UseCase.UserServices.MediatR.Handlers
{
    public class VerifyUserService(IMapper mapper, IUserService userService, ICryptService cryptService, IJwtService jwtService) : IRequestHandler<VerifyUserCommand, VerifyUserResponce>
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
