namespace BusinessLib.Bl.Contract
{


    public interface IPractitionerSpecialFeatures<T>
    {

        bool Save(TbPractitioner element, TbPerson element2, TbPractitionerSpec element3, List<TbPractitionerCase> list);
        IQueryable GetAllCasesBasedOnPractitionerTypeId(int practitionerTypeId);

    }


}
