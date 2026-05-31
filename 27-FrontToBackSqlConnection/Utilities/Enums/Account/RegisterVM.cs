using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.Utilities.Enums.Account
{
    public class RegisterVM
    {
        [MaxLength(20, ErrorMessage = "swyww")]
        [MinLength(3, ErrorMessage = "Can't be less than 3")]
        public string Name { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string Surname { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
