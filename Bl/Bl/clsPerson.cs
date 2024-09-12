using BusinessLib.Bl.Contract;
using BusinessLib.Data;

namespace BusinessLib.Bl
{
    public class clsPerson:ICRUD<TbPerson>,ITransactionOperations<TbPerson>
    {
        private readonly ICRUD<TbPerson> _clsGenericRepository;
        private readonly ITransactionOperations<TbPerson> _clsGenericTransactionRepository;

        public clsPerson(ICRUD<TbPerson> Repository, ITransactionOperations<TbPerson> transactionRepository)
        {
            _clsGenericRepository = Repository;
            _clsGenericTransactionRepository = transactionRepository;

        }

        public IQueryable<TbPerson> GetAll()
        {

            return _clsGenericRepository.GetAll();

        }
        public TbPerson GetById(int elementId)
        {

            return _clsGenericRepository.GetById(elementId);
        }
        public int? Save(TbPerson element)
        {

            return _clsGenericRepository.Save(element);

        }
        public bool Delete(int elementId)
        {

            return _clsGenericRepository.Delete(elementId);


        }

        public int? SaveTransaction(TbPerson element, DbContext dbContext)
        {
            return _clsGenericTransactionRepository.SaveTransaction(element, dbContext);
        }
    }
}
