using UseCase.AuthorisationServices.Services.DTOs;

namespace UseCase.AuthorisationServices.Services
{
    public class CryptService
    {
        public string CreatePasswordHash(CreatePasswordHashDTO createPasswordHashDTO)
        {
            return BCrypt.Net.BCrypt.HashPassword(createPasswordHashDTO.Password);
        }

        public bool VerifyPassword(VerifyPasswordDTO verifyPasswordDTO)
        {
            return BCrypt.Net.BCrypt.Verify(verifyPasswordDTO.Password, verifyPasswordDTO.Hash);
        }
    }
}
