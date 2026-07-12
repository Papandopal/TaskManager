using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace UseCase.AuthorisationServices
{
    public class AuthentificationOptions(IConfiguration configuration)
    {
        public string ISSUER { get; } = configuration["JWTBearer:ISSUER"] ?? throw new Exception("\"ISSUER\" not found in configuration");

        public string AUDIENCE { get; } = configuration["JWTBearer:AUDIENCE"] ?? throw new Exception("\"ISSUER\" not found in configuration");
        public string KEY { get; } = configuration["JWTBearer:KEY"] ?? throw new Exception("\"ISSUER\" not found in configuration");
        public SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
