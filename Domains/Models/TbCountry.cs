
namespace Domains.Models
{
    public class TbCountry
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<TbPerson> TbPeople {  get; set; }
        public TbCountry()
        {
            TbPeople=new HashSet<TbPerson>();
        }

    }
}
