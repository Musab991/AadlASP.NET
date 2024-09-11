
using Domains.Utility;

namespace Domains.Models
{
    public class TbPractitioner
    {
        public TbPractitioner()
        {
            TbPractitionerSpec = new TbPractitionerSpec();
            TbPerson = new TbPerson();

        }
        public int Id { get; set; }//constant 
        [Required]
        public int PractitionerTypeId{  get; set; }//constant 

		public int ?PractitionerSpecId {  get; set; }  //constant 

		public int PersonId {  get; set; }//constant 

        public int CreatedByUserId {  get; set; }

        public DateTime CreatedDate { get; set; }
        public int ?UpdatedByUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

		public virtual TbPractitionerSpec TbPractitionerSpec { get; set; }//changes might happen here ..inside the composed class outer my area
        public virtual TbPerson TbPerson { get; set; }

    }

}

