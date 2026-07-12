using UseCase.UserServices.Services.DTOs;

namespace UseCase.UserServices.Services
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
