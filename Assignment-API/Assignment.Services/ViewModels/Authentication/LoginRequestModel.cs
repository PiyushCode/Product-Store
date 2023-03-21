using System.ComponentModel.DataAnnotations;

namespace Assignment.Services.ViewModels.Authentication
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
