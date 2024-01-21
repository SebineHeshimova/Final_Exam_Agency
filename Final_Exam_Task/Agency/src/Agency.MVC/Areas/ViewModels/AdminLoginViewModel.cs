using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Agency.MVC.Areas.ViewModels
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength:50, MinimumLength =3)]
        [Required]
        public string UserName { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
