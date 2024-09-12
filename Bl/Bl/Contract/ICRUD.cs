using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Bl.Contract
{
    public interface ICRUD<T>
    {
        IQueryable<T> GetAll();
        T GetById(int elementId);
        int? Save(T element);
        bool Delete(int elementId);

    }
    public interface ITransactionOperations<T>
    {

        int? SaveTransaction(T element,DbContext dbContext);
    }


}
