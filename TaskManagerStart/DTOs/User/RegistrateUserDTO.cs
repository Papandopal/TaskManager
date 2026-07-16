namespace TaskManagerStart.DTOs.User
{
    public class RegistrateUserDTO
    {
        public string Email { get; set; } 
        public string Password { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
