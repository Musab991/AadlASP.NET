namespace BusinessLib.Bl.Contract
{
    public interface IPractitionerService<T>
    {
        IQueryable<T> GetAll(int practitionerTypeId);
        T GetById(int caseId,int practitionerTypeId);
        bool Save(T element, int practitionerTypeId);
        bool Delete(int caseId, int practitionerTypeId);

    }


}
