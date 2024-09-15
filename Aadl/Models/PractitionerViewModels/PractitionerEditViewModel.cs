using System.ComponentModel.DataAnnotations;

namespace Aadl.Models.PractitionerViewModels
{
	public class PractitionerEditViewModel :PractitionerViewModel
    {
        //Person Info ,
        
        public int PersonId {  get; set; }
        public string? Email { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string? City { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }


        /////////////shared////////////////////////
        public int? UpdatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }


        //////////////////////////////////////////


        //practitioner Info 
        public List<int> PractitionerCases { get; set; } = null!;
        public int PractitionerSpecId {  get; set; }
  
        //regulator
        public string? RegulatorMembership { get; set; } = null;
        //sharia
        public string? ShariaLicenseNumber { get; set; } = null;

    }
   

}
