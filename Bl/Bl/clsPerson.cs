using BusinessLib.Bl.Contract;
using BusinessLib.Data;

namespace BusinessLib.Bl
{
    public class clsPerson:ICRUD<TbPerson>
    {
        private readonly AppDbContext _appDbContext;
        public clsPerson(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IQueryable<TbPerson> GetAll()
        {
            try
            {

                return _appDbContext.TbPeople.AsNoTracking().OrderBy(x => x.FullName).AsQueryable();
            }
            catch (Exception ex)
            {

                return new List<TbPerson>().AsQueryable();  
            }

        }
        public TbPerson GetById(int elementId)
        {

            try
            {

                return _appDbContext.TbPeople.SingleOrDefault(x => x.Id == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbPerson element)
        {
            try
            {

                if (element.Id == 0)
                {
                    _appDbContext.TbPeople.Add(element);
                    if (_appDbContext.SaveChanges() > 0)
                    {
                        return true;
                    }
                }


                else
                {
                    _appDbContext.Entry(element).State = EntityState.Modified;

                    if (_appDbContext.SaveChanges() > 0)
                    {
                        return true;
                    }
                }



                return false;
            }
            catch (Exception ex) { return false; }

        }
        public bool Delete(int elementId)
        {

            try
            {

                TbPerson elementToDelete = GetById(elementId);
                _appDbContext.TbPeople.Remove(elementToDelete);
                if (_appDbContext.SaveChanges() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }
   

    }
}
