
namespace Domains.Models
{
    public class TbPractitionerCase
    {
        [Key]
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int CaseId { get; set; }
        [Required]
        public int PractitionerTypeId{ get; set; }
        [NotMapped]
        public virtual TbCaseType ?TbCaseType{get;set;}
        [NotMapped]

        public virtual TbPractitioner? TbPractitioner { get; set; }
     

    }


}
