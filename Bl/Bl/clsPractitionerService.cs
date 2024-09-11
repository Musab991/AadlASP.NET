


namespace BusinessLib.Bl
{
    public class clsPractitionerService : IPractitionerService<TbCaseType>
    {
        private readonly AppDbContext _appDbContext;
        public clsPractitionerService(AppDbContext appDbContextSerivce)
        {
            _appDbContext = appDbContextSerivce;
        }
        public bool Delete(int caseId, int practitionerTypeId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TbCaseType> GetAll(int practitionerTypeId)
        {
            try
            {
                return _appDbContext.TbCaseTypes
                         .AsNoTracking()
                         .Where(c=>c.PractitionerTypeId== practitionerTypeId)
                         .OrderBy(x => x.Name)
                         .AsQueryable();

            }
            catch (Exception ex)
            {

                return new List<TbCaseType>().AsQueryable();
            }

        }

        public TbCaseType GetById(int caseId, int practitionerTypeId)
        {
            throw new NotImplementedException();
        }

        public bool Save(TbCaseType element, int practitionerTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
