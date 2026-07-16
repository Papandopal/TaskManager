using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UserServices.Services.DTOs;

namespace UseCase.UserServices.Services.Interfaces
{
    public interface IJwtService
    {
        public JwtSecurityToken GenerateJwtTokent(GenerateJwtDTO generateJwtDTO);
    }
}
