using Aadl.Models.PractitionerViewModels;
using Domains.Utility;

namespace Aadl.Models.General
{
    public static class Mapper
    {
        public static void MapCasesToPractitionerEditViewModel(List<TbPractitionerCase> PractitionerCases, PractitionerEditViewModel model)
        {

            model.PractitionerCases = PractitionerCases.Select(pc => pc.CaseId).ToList();
        }
        public static void MapSpecToPractitionerEditViewModel(TbPractitionerSpec practitionerSpec, PractitionerEditViewModel model)
        {

            {

                try
                {



                    model.PractitionerSpecId = practitionerSpec.Id;
                    model.PractitionerType = (Enums.PractitionerTypeEnum)practitionerSpec.PractitionerTypeId;
                    model.SubscriptionType = practitionerSpec.SubscriptionType;
                    model.SubscriptionWay = practitionerSpec.SubscriptionWay;
                    model.PractitionerId = practitionerSpec.PractitionerId;
                    model.CreatedByUserId = practitionerSpec.CreatedByUserId;
                    model.CreatedDate = practitionerSpec.CreatedDate;
                    model.UpdatedByUserId = practitionerSpec.UpdatedByUserId;
                    model.LastUpdateDate = practitionerSpec.UpdatedDate;
                    model.RegulatorMembership = practitionerSpec.RegulatorMembershipNumber;
                    model.ShariaLicenseNumber = practitionerSpec.ShariaLicenseNubmer;
                    model.IsActive = true;

                }
                catch (InvalidCastException)
                {
                    // Handle the case where the cast fails
                }


            }
        }
        public static void MapPersonToPractitionerEditViewModel(PractitionerEditViewModel model, TbPerson person)
        {
            try
            {

                model.PersonId = person.Id;
                model.FullName = person.FullName;
                model.Birthday = person.Birthday;
                model.City = person.City;
                model.CountryId = person.CountryId;
                model.Email = person.Email;
                model.Phone = person.Phone;

            }
            catch (InvalidCastException ex)
            {
                // Log or handle exceptions if the cast fails
                throw new InvalidOperationException("Error mapping PractitionerEditViewModel to TbPerson", ex);
            }
        }
        public static  TbPerson MapPractitionerEditViewModelToPerson(PractitionerEditViewModel model)
        {

            try
            {
                TbPerson person = new TbPerson();

                person.Id = model.PersonId;
                person.FullName = model.FullName;
                person.Birthday = model.Birthday;
                person.City = model.City;
                person.CountryId = model.CountryId;
                person.Email = model.Email;
                person.Phone = model.Phone;

                return person;
            }
            catch (InvalidCastException)
            {
                return null;
                // Handle the case where the cast fails
            }


        }
        public static TbPractitionerSpec MapPractitionerEditViewModelToSpec(PractitionerEditViewModel model)
        {
            try
            {
                TbPractitionerSpec practitionerSpec = new TbPractitionerSpec();
                practitionerSpec.Id = model.PractitionerSpecId;
                practitionerSpec.PractitionerTypeId = (int)model.PractitionerType; // Cast enum to int
                practitionerSpec.SubscriptionType = model.SubscriptionType;
                practitionerSpec.SubscriptionWay = model.SubscriptionWay;
                practitionerSpec.PractitionerId = model.PractitionerId;
                practitionerSpec.CreatedByUserId = model.CreatedByUserId;
                practitionerSpec.CreatedDate = model.CreatedDate;
                practitionerSpec.UpdatedByUserId = model.UpdatedByUserId;
                practitionerSpec.UpdatedDate = model.LastUpdateDate;
                practitionerSpec.RegulatorMembershipNumber = model.RegulatorMembership;
                practitionerSpec.ShariaLicenseNubmer = model.ShariaLicenseNumber;
                //practitionerSpec.IsActive = model.IsActive; // Assuming you have a property for active status


                return practitionerSpec;
            }
            catch (InvalidCastException ex)
            {
                // Log or handle exceptions if the cast fails
                throw new InvalidOperationException("Error mapping PractitionerEditViewModel to TbPractitionerSpec", ex);
            }
        }
        public static List<TbPractitionerCase> MapPractitionerEditViewModelToCases(PractitionerEditViewModel model)
        {
            try
            {
                var cases = model.PractitionerCases.Select(caseId => new TbPractitionerCase
                {
                    CaseId = caseId,
                    PractitionerId = model.PractitionerId,
                    PractitionerTypeId = (int)model.PractitionerType
                }).ToList();

                return cases;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new InvalidOperationException("Error mapping PractitionerEditViewModel to cases", ex);
            }
        }
        public static TbPractitioner MapPractitionerEditViewModelToPractitioner(PractitionerEditViewModel model)
        {
            try
            {

                TbPractitioner practitionerModel = new TbPractitioner()
                {
                    Id = model.PractitionerId,
                    PersonId = model.PersonId
                };
                return practitionerModel;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new InvalidOperationException("Error mapping PractitionerEditViewModel to cases", ex);
            }
        }

    }
}
