

using Domains.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace BusinessLib.Bl
{
    public class clsPractitioner: ICRUD<TbPractitioner>, ITransactionOperations<TbPractitioner>
    {
        private readonly ICRUD<TbPractitioner> _clsGenericRepository;
        private readonly ITransactionOperations<TbPractitioner> _clsGenericTransactionRepository;

        public clsPractitioner(ICRUD<TbPractitioner> Repository, ITransactionOperations<TbPractitioner> transactionRepository)
        {
            _clsGenericRepository = Repository;
            _clsGenericTransactionRepository = transactionRepository;

        }

        public IQueryable<TbPractitioner> GetAll()
        {

            return _clsGenericRepository.GetAll();

        }
        public TbPractitioner GetById(int elementId)
        {

            return _clsGenericRepository.GetById(elementId);
        }
        public int? Save(TbPractitioner element)
        {

            return _clsGenericRepository.Save(element);

        }
        public bool Delete(int elementId)
        {

            return _clsGenericRepository.Delete(elementId);


        }

        public int? SaveTransaction(TbPractitioner element, DbContext dbContext)
        {
            return _clsGenericTransactionRepository.SaveTransaction(element, dbContext);
        }


    }
}
