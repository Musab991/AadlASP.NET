using BusinessLib.Bl.Contract;
using Domains.Models;

namespace BusinessLib.Bl
{
    public class clsPractitionerCase: IPractitionerCaseSpecialMethods<TbPractitionerCase>
    {

        public clsPractitionerCase()
        {
        }
        public bool SaveTransaction(List<TbPractitionerCase> lstPractitionerCases,
            AppDbContext appDbContext)
        {
      
            try
            {

                List<TbPractitionerCase> lstPractitionerCasesInDatabase=new List<TbPractitionerCase>();


                if (!(lstPractitionerCases is null)&&lstPractitionerCases.Any())
                {
                    TbPractitionerCase practitionerCase = lstPractitionerCases.FirstOrDefault();

                 lstPractitionerCasesInDatabase =
                       appDbContext.TbPractitionerCases
                       .Where(x => x.PractitionerId == practitionerCase.PractitionerId&&
                       x.PractitionerTypeId == practitionerCase.PractitionerTypeId)
                       .ToList();
                }

                foreach (var practitionerCase in lstPractitionerCases)
                {

                   

                    //are in both database ,and lstPractitionerCases (edit)
                    if (lstPractitionerCasesInDatabase.Where(x => x.PractitionerId == practitionerCase.PractitionerId
                    && x.PractitionerTypeId == practitionerCase.PractitionerTypeId
                     && x.CaseId == practitionerCase.CaseId).Any())
                    {
                        appDbContext.Entry(practitionerCase).State = EntityState.Modified;

                    }


                    //is not in database ,nor in list I have (add)
                    else if (!lstPractitionerCasesInDatabase.Where(x => x.PractitionerId == practitionerCase.PractitionerId
                    && x.PractitionerTypeId == practitionerCase.PractitionerTypeId
                    && x.CaseId == practitionerCase.CaseId).Any())
                    {
                        appDbContext.TbPractitionerCases.Add(practitionerCase);
                    }

                }

                //to remove ...//in database ,but out of my hands ..
                foreach (TbPractitionerCase practitionerCase in lstPractitionerCasesInDatabase)
                {

                    if (!lstPractitionerCases.Where(x=> x.PractitionerId== practitionerCase.PractitionerId
                    && x.PractitionerTypeId == practitionerCase.PractitionerTypeId
                    &&x.CaseId==practitionerCase.CaseId).Any())
                    {

                        appDbContext.Remove(practitionerCase);
                    }
                }
                appDbContext.SaveChanges();

                //in one 
                return true;

            }

            catch (Exception ex)
            {

                return false;
            }
    

        }

    }

}