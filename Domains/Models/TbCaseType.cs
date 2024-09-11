namespace Domains.Models
{
    public class TbCaseType
    {
        [Key]
        public int Id{ get; set; }
        [Required]  
        public string Name { get; set; } = null!;
        [Required]
        public int PractitionerTypeId { get; set; }


    }


}
