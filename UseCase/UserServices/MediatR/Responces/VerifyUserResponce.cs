using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.AuthorisationServices.MediatR.Responces
{
    public class VerifyUserResponce
    {
        public string JwtToken { get; set; } = string.Empty;
    }
}
