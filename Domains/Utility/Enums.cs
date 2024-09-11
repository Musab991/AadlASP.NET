

namespace Domains.Utility
{
    public class Enums
    {
        public enum PractitionerTypeEnum:byte
        {
            [Display(Name ="نظامي")]
            Regulator=1,
            [Display(Name = "شرعي")]

            Sharia=2,
            [Display(Name = "محكم")]
            Judger=3,
            [Display(Name = "خبير")]

            Expert=4
        }

        public enum SubscriptionTypeEnum:byte
        {

            [Display(Name = "مجاني")]

            Free = 1,
            [Display(Name = "متوسط")]

            Average,
            [Display(Name = "خبير")]

            Special
        }

        public enum SubscriptionWayEnum:byte
        {
            [Display(Name = "دعم خاص")]
            Support =1,
            [Display(Name = "منحة")]
            Scholarship
        }

    }
}
