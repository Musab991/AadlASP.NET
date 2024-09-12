namespace BusinessLib.Bl.Contract
{
    public interface ISpecialRetriveToData<T>
    {

        IQueryable GetAll(int value);

    }

}
