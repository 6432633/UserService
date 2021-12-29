using System.ComponentModel.DataAnnotations;

namespace UserService.Models{
    public class User{
        [Key]
        public Guid Id{get;set;}
        [Required]
        public string Name{get;set;}
        [Required]
        public string Username{get;set;}
        [Required]
        public string Password{get;set;}
        public string? Api_Key{get;set;}
        public string? DatabaseName{get;set;}
        public string? ConnectionString{get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime? UpdatedAt{get;set;}
        public DateTime? DeletedAt{get;set;}

    }
}