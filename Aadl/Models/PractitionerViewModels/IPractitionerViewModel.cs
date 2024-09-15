using Domains.Utility;

namespace Aadl.Models.PractitionerViewModels
{
    public abstract class PractitionerViewModel
    {
        public Enums.PractitionerTypeEnum PractitionerType { get; set; }
        public Enums.SubscriptionTypeEnum SubscriptionType { get; set; }
        public Enums.SubscriptionWayEnum SubscriptionWay{ get; set; }

        public string FullName { get; set; }=null!;
        public string Phone { get; set; } = null!;
        public int PractitionerId { get; set; }
        public bool IsActive { get; set; }
        
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }

    }


}
