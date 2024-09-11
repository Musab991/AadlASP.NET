using System.ComponentModel.DataAnnotations;

namespace Aadl.Models.PractitionerViewModels
{
	public class PractitionerEditViewModel
    {
        //Person Info ,
        
        public int PersonId {  get; set; }
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string? City { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }


        /////////////shared////////////////////////
        public int? UpdatedByUserId { get; set; } = null;
        public DateTime? LastUpdateDate { get; set; } = null;

        //////////////////////////////////////////


        //practitioner Info 
        public int PractitionerId { get; set; }
        public int PractitionerTypeId { get; set; }
        public List<int> PractitionerCases { get; set; } = null!;

        public int SubscriptionTypeId { get; set; } 
        public int SubscriptionWayId { get; set; } 
        public bool IsActive { get; set; }
        //regulator
        public string? RegulatorMembership { get; set; } = null;
        //sharia
        public string? ShariaLicenseNumber { get; set; } = null;

    }
   

}
