using BusinessLib.Bl.Contract;
using BusinessLib.Data;

namespace BusinessLib.Bl
{
    public class clsCountry : ICRUD<TbCountry>
    {   

        private readonly AppDbContext _appDbContext;
        public clsCountry(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IQueryable<TbCountry> GetAll()
        {
            try
            {

                return _appDbContext.TbCountries.AsNoTracking().OrderBy(x => x.Name).AsQueryable();
            }
            catch (Exception ex)
            {

                return new List<TbCountry>().AsQueryable();
            }

        }
        public TbCountry GetById(int elementId)
        {

            try
            {

                return _appDbContext.TbCountries.SingleOrDefault(x => x.Id == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbCountry element)
        {

            try
            {

                if (element.Id == 0)
                {
              
                    _appDbContext.TbCountries.Add(element);
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

                TbCountry categoryToDelete = GetById(elementId);
                _appDbContext.TbCountries.Remove(categoryToDelete);
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
