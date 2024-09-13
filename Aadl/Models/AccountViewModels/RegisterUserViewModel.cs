using System.ComponentModel.DataAnnotations;

namespace Aadl.Models.AccountViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "اسم المستخدم مطلوب.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب.")]
        [MaxLength(256, ErrorMessage = "البريد الإلكتروني يجب ألا يزيد عن 256 حرف.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "يرجى إدخال بريد إلكتروني صحيح.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "يجب أن تكون كلمة المرور مكونة من 6 أحرف على الأقل وتحتوي على حرف كبير، حرف صغير، رقم، وحرف خاص.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور وتأكيدها غير متطابقين.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
