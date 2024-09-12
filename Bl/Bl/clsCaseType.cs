namespace BusinessLib.Bl
{
    public class clsCaseType : ICRUD<TbCaseType>, ISpecialRetriveToData<TbCaseType>
    {
        private readonly AppDbContext _appDbContext;

        private readonly ICRUD<TbCaseType> _clsGenericRepository;
        public clsCaseType(AppDbContext appDbContextSerivce, ICRUD<TbCaseType> countryRepository)
        {
            _clsGenericRepository = countryRepository;
            _appDbContext = appDbContextSerivce;
        }
        public IQueryable<TbCaseType> GetAll()
        {

            return _clsGenericRepository.GetAll();

        }
        public TbCaseType GetById(int elementId)
        {

            return _clsGenericRepository.GetById(elementId);
        }
        public int? Save(TbCaseType element)
        {

            return _clsGenericRepository.Save(element);

        }
        public bool Delete(int elementId)
        {

            return _clsGenericRepository.Delete(elementId);


        }

        /// <summary>
        /// return all cases from datbase based on practitioner type id.
        /// </summary>
        /// <param name="practitionerTypeId">to determine type of cases to be return from database</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable GetAll(int practitionerTypeId)
        {
            try
            {

                return _appDbContext.TbCaseTypes.Where(cs=>cs.PractitionerTypeId == practitionerTypeId).AsQueryable();

            }
            catch (Exception ex) { 
            
                Console.WriteLine(ex.Message,ex);

                return null;
            }
        }
    }

}
