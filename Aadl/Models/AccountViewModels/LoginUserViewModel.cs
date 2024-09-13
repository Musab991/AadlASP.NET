using System.ComponentModel.DataAnnotations;

namespace Aadl.Models.AccountViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "اسم المستخدم مطلوب.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
