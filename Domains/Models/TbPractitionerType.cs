
namespace Domains.Models
{
    public class TbPractitionerType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public PractitionerTypeEnum PractitionerTypeName { get; set; }


    }

}
