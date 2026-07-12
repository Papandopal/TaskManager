using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using UseCase.AuthorisationServices.Services.DTOs;

namespace UseCase.AuthorisationServices.Services
{
    public class JwtService(AuthentificationOptions authentificationOptions)
    {
        public JwtSecurityToken GenerateJwtTokent(GenerateJwtDTO generateJwtDTO)
        {
            var claims = GetClaimsByDTO(generateJwtDTO);
            var jwt = new JwtSecurityToken(
                    issuer: authentificationOptions.ISSUER,
                    audience: authentificationOptions.AUDIENCE,
                    claims: claims,
                    signingCredentials: new SigningCredentials(authentificationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return jwt;
        }

        private List<Claim> GetClaimsByDTO(GenerateJwtDTO generateJwtDTO)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, generateJwtDTO.UserId.ToString()));

            return claims;
        }
    }
}
