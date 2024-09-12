namespace BusinessLib.Bl.Contract
{
    public interface IPractitionerCaseSpecialMethods<T>
    {

        bool SaveTransaction(List<T> lstelements,AppDbContext appDbContext);

    }

}
