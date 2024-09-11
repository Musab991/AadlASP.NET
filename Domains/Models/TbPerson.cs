
namespace Domains.Models
{
    public class TbPerson
    {

        [Key]
        [ValidateNever]
        public int Id { get; set; }
        public string FirstName { get; set; } = null! ;
        public string SecondName { get; set; } = null!;
        public string? ThirdName { get; set; } 
        public string LastName { get; set; } = null!;

        [NotMapped]
        public string FullName { get
            {
                return
                FirstName + " " + " " + SecondName + " " + ThirdName + " " + LastName;
            } }

        [Phone]
        public string Phone { get; set; } =null!;

        public string? Email { get; set; } = string.Empty;

        [Required]
        [ValidateNever]
        public int CreatedByUserId { get; set; }
        [Required]
        [ValidateNever]
        public DateTime CreationDate{ get; set; }
        [ValidateNever]
        public int ?UpdateByUserId { get; set; }
        [ValidateNever]
        public int ?UpdateDate { get; set; }
        public DateTime? Birthday { get; set; }
        public int CountryId { get; set; }
        public string ? City {  get; set; }
        public virtual TbCountry TbCountry { get; set; }
        public TbPerson()
        {
            TbCountry = new TbCountry();
        }


    }


}
