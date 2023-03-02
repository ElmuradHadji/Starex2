using System.ComponentModel.DataAnnotations;

namespace Core.Entities.DTOs.UserDTOs
{
    public class AdminRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }
        public string? Role { get; set; }
    }
}
