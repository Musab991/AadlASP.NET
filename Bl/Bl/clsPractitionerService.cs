using BusinessLib.Bl.Contract;

namespace BusinessLib.Bl
{
    public class clsPractitionerService<T> : IPractitionerSpecialFeatures<T>
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITransactionOperations<TbPerson>_clsPerson;
        private readonly ITransactionOperations<TbPractitioner> _clsPractitioner;
        private readonly ITransactionOperations<TbPractitionerSpec> _clsPractitionerSpec;
        private readonly IPractitionerCaseSpecialMethods<TbPractitionerCase> _clsPractitionerCase;
        private readonly ISpecialRetriveToData<TbCaseType> _clsCaseType;

        public clsPractitionerService(AppDbContext appDbContextSerivce, ITransactionOperations<TbPerson> clsPerson,
            ITransactionOperations<TbPractitioner> clsPractitioner, ITransactionOperations<TbPractitionerSpec> clsPractitionerSpec,
            IPractitionerCaseSpecialMethods<TbPractitionerCase> practitionerCaseService,
            ISpecialRetriveToData<TbCaseType> caseTypeService)
        {
            _appDbContext = appDbContextSerivce;
            _clsPerson = clsPerson;
            _clsPractitioner = clsPractitioner;
            _clsPractitionerSpec = clsPractitionerSpec;
            _clsPractitionerCase = practitionerCaseService;
            _clsCaseType= caseTypeService;
        }
        /// <summary>
        /// it reutrns list of cases that not submitted to any practitioner,based on practitioner type(R,S,E,J)
        /// </summary>
        /// <param name="practitionerTypeId"></param>
        /// <returns></returns>
        public IQueryable GetAllCasesBasedOnPractitionerTypeId(int practitionerTypeId)
        {
            try
            {
                return  _clsCaseType.GetAll(practitionerTypeId);

            }
            catch (Exception ex)
            {

                return new List<TbCaseType>().AsQueryable();
            }

        }
    
        public  bool Save(TbPractitioner practitionerModel,TbPerson personModel,
            TbPractitionerSpec practitionerSpecModel,List<TbPractitionerCase>lstPractitionerCases)
        {
            try
            {

                using (var transaction =  _appDbContext.Database.BeginTransaction()) 
                {

                    int? PersonId = _clsPerson.SaveTransaction(personModel, _appDbContext);

                    if (PersonId is null || PersonId == 0)
                    {
                        transaction.Rollback();
                        throw new NullReferenceException("Cannot insert new/update person into database");
                    }

                    practitionerModel.PersonId = Convert.ToInt32(PersonId);

                    int? PractitionerId = _clsPractitioner.SaveTransaction(practitionerModel,_appDbContext);

                    if (PractitionerId is null || PractitionerId == 0)
                    {
                        transaction.Rollback();
                        throw new NullReferenceException("Cannot insert new practitioner into database");
                    }

                    int? PractitionerSpecId = _clsPractitionerSpec.SaveTransaction(practitionerSpecModel, _appDbContext);

                    if (PractitionerSpecId is null || PractitionerSpecId == 0)
                    {
                        transaction.Rollback();
                        throw new NullReferenceException("Cannot insert new practitionerSpec into database");
                    }
                    
                    if (!_clsPractitionerCase.SaveTransaction(lstPractitionerCases,_appDbContext))
                    {
                        transaction.Rollback();

                        throw new NullReferenceException("Cannot insert new cases into database");

                    }

                    transaction.Commit();

                    return true;

                }
            }
            catch (Exception ex) {
                return false;
                throw new NullReferenceException("Cannot insert new practitioner into database\t", ex);
            }
        }

    }

}
