using System.ComponentModel.DataAnnotations;

namespace UserService.DTO
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Api_Key { get; set; }
        public string? DatabaseName { get; set; }
        public string? ConnectionString { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
