namespace BusinessLib.Bl
{
    public class clsPractitionerSpec : ICRUD<TbPractitionerSpec>
    {

        private readonly ICRUD<TbPractitionerSpec> _clsGenericRepository;
        public clsPractitionerSpec(ICRUD<TbPractitionerSpec> countryRepository)
        {
            _clsGenericRepository = countryRepository;
        }
        public IQueryable<TbPractitionerSpec> GetAll()
        {

            return _clsGenericRepository.GetAll();

        }
        public TbPractitionerSpec GetById(int elementId)
        {

            return _clsGenericRepository.GetById(elementId);
        }
        public int? Save(TbPractitionerSpec element)
        {

            return _clsGenericRepository.Save(element);

        }
        public bool Delete(int elementId)
        {

            return _clsGenericRepository.Delete(elementId);


        }



    }

}
