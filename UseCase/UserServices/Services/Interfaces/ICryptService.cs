using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.UserServices.Services.DTOs;

namespace UseCase.UserServices.Services.Interfaces
{
    public interface ICryptService
    {
        public string CreatePasswordHash(CreatePasswordHashDTO createPasswordHashDTO);
        public bool VerifyPassword(VerifyPasswordDTO verifyPasswordDTO);
    }
}
