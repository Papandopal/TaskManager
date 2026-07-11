using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.AuthorisationServices.Services.DTOs
{
    public class VerifyPasswordDTO
    {
        public string Password { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }
}
