using BusinessLib.Bl.Contract;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Bl
{
    public class clsPractitioner: ICRUD<TbPractitioner>
    {
        private readonly AppDbContext _appDbContext;
        public clsPractitioner(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public IQueryable<TbPractitioner> GetAll()
        {
            try
            {
                return _appDbContext.TbPractitioners.AsNoTracking().OrderBy(x => x.Id).AsQueryable();
            
            }
            catch (Exception ex)
            {

                return new List<TbPractitioner>().AsQueryable();
            }

        }
        public TbPractitioner GetById(int elementId)
        {

            try
            {

                return _appDbContext.TbPractitioners.SingleOrDefault(x => x.Id == elementId);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public bool Save(TbPractitioner element)
        {
            try
            {

                if (element.Id == 0)
                {
                    _appDbContext.TbPractitioners.Add(element);
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
            catch (Exception ex)
            { return false; }

        }
        public bool Delete(int elementId)
        {

            try
            {

                TbPractitioner elementToDelete = GetById(elementId);
                _appDbContext.TbPractitioners.Remove(elementToDelete);
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
