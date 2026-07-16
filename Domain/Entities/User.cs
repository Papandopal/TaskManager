namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
