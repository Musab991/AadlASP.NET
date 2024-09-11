namespace Aadl.Models.PractitionerViewModels
{
	public class PractitionerEditViewModel
    {
        //Person Info , practitioner Info 
        public int PractitionerId { get; set; }
        public string FullName { get; set; } = null!;
        public int PractitionerTypeId { get; set; }
        public List<int> PractitionerCases { get; set; } = null!;
        public int? UpdatedByUserId { get; set; } = null;
        public DateTime? LastUpdateDate { get; set; } = null;
        public int SubscriptionTypeId { get; set; } 
        public int SubscriptionWayId { get; set; } 
        public bool IsActive { get; set; }
   

 
    }
    public class RegulatorEditViewModel : PractitionerEditViewModel
    {
        //regulator
        public string? RegulatorMembership { get; set; } = null;
    }
    public class ShariaEditViewModel : PractitionerEditViewModel
    {
        //sharia
        public string? ShariaLicenseNumber { get; set; } = null;

    }

}
