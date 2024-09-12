using Aadl.Models.General;
using Aadl.Models.PractitionerViewModels;
using BusinessLib.Bl.Contract;
using Domains.Models;
using Domains.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Numerics;
using System.Text.Json;

namespace Aadl.Controllers
{
    public class PractitionerController : Controller
    {

        private readonly ICRUD<TbPractitioner> _clsPractitioner;
        private readonly ICRUD<TbCountry> _clsCountry;
        private readonly IPractitionerSpecialFeatures<TbPractitioner> _clsPractitionerService;
        public PractitionerController(ICRUD<TbPractitioner>practitionerService01,
             IPractitionerSpecialFeatures<TbPractitioner> practitionerService, ICRUD<TbCountry> counrtyService)
        {
            _clsPractitioner = practitionerService01;
            _clsPractitionerService = practitionerService;
            _clsCountry = counrtyService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            try
            {

                var result = _clsPractitioner.GetAll().Select(p => new PractitionerListViewModel()
                {
                    PractitionerId = p.Id,
                    CreatedByUser = p.CreatedByUserId.ToString(),
                    IsActive = true, //change later on to isDelete
                    PractitionerCases = new List<string>() { "case1", "case2", "case3" },
                    PractitionerType = "type",
                    SubscriptionType = "subscriptionFree",
                    SubscriptionWay = "SupportSubscriptionWay"


                }).ToList();

                var practitioner = new PractitionerListViewModel()
                {
                    PractitionerId = 1,
                    FullName="مصعب محمود علي عطية",
                    CreatedByUser = "خالد_",
                    IsActive = true, //change later on to isDelete
                    PractitionerCases = new List<string>() { "قضية1", "قضية2", "قضية3" },
                    PractitionerType = "نظامي",
                    SubscriptionType = "مجاني",
                    SubscriptionWay = "دعم خاص"
                };
                result.Add(practitioner);
            //map to View-List-Model

            return View(result);
            }
            catch (Exception ex)
            {

                throw new NullReferenceException();
            }

        }

        [HttpGet]
        public async Task<IActionResult>Edit(int? practitionerId , int practitionerTypeId)
        {
            try
            {
                if (practitionerId != null && practitionerTypeId != 0) { 
                var practitioner = _clsPractitioner.GetById(Convert.ToInt32(practitionerId));
                }

                ////map to edit model
                //PractitionerEditViewModel model = new PractitionerEditViewModel()
                //{
                //     FullName=practitioner.TbPerson.FullName,
                //     IsActive=true,
                //     LastUpdateDate=DateTime.Now,
                //     PractitionerCases=new List<int>(),
                //     PractitionerId=entityId,
                //}

                ViewBag.PractitionerCases = _clsPractitionerService.GetAllCasesBasedOnPractitionerTypeId(practitionerTypeId);
                ViewBag.PractitionerTypeId = practitionerTypeId;
                IEnumerable<TbCountry> lst = new List<TbCountry>
                {
                    new TbCountry { Id = 1, Name = "s" }
                };
                //ViewBag.Countries = _clsCountry.GetAll().ToList();
                ViewBag.Countries = _clsCountry.GetAll();

                PractitionerEditViewModel Editmodel = new PractitionerEditViewModel()
                {
                    FullName = "مصعب محمود علي عطية",
                    IsActive = true,
                    PractitionerCases = new List<int>() { 4,5 },
                    PractitionerId = 1,
                    PractitionerTypeId = 2,
                    SubscriptionTypeId = 1,
                    SubscriptionWayId = 1,
                    CreatedByUserId=1,
                    IssueDate = new DateTime(2024,03,12),
                    PersonId = 4,
                    CountryId = 1,
                    City = "المدينة",
                    Phone="00962780852829",
                    Birthday = new DateTime(1997, 03, 31),
                    RegulatorMembership = string.Empty,
                    ShariaLicenseNumber = "1923810"
                };
                PractitionerEditViewModel Addmodel = new PractitionerEditViewModel()
                {
                    //FullName = "",
                    //IsActive = true,
                    //PractitionerCases = new List<int>() { 4, 5 },
                    //PractitionerId = 1,
                    //PractitionerTypeId = 1,
                    //SubscriptionTypeId = 1,
                    //SubscriptionWayId = 1,
                    //CreatedByUserId = 1,
                    //IssueDate = new DateTime(2024, 03, 12),
                    //PersonId = 4,
                    //CountryId = 1,
                    //City = "المدينة",
                    //Phone = "00962780852829",
                    //Birthday = new DateTime(1997, 03, 31),
                    //RegulatorMembership = string.Empty,
                    //ShariaLicenseNumber = "1923810"
                };

                ViewBag.Title = "أضافة و تعديل بيانات المزاول";
                ViewBag.SubTitle = "نظامي";

                return View(Addmodel);
            
            }
            catch (Exception ex) {

                RedirectToAction("Index");
                throw new ArgumentNullException(nameof(practitionerId));
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(PractitionerEditViewModel model)
        {
            try
            {

            //I could send it with viewBag[RegulatorMemberShip]
            if (ModelState.IsValid)
                {
                    ViewBag.PractitionerTypeId = model.PractitionerTypeId;
                    SavePractitioner(model);

                    //busines layer save through ef in database transaction method...
                    // Handle the model
                    // Example: Save or update the model data
                    return RedirectToAction("Index");
                }
            } catch (Exception ex) {
            
                //handle 
            }
            return View(model);

        }

        public bool SavePractitioner(PractitionerEditViewModel model)
        {
            // Map view model to entity models manually

            model.CreatedByUserId = 1;
            model.IssueDate = DateTime.Now;
            // Map TbPerson
            var personModel = new TbPerson
            {
                Id=model.PersonId,
                FullName=model.FullName,
                Birthday=model.Birthday,
                City=model.City,
                Phone=model.Phone,
                CountryId=model.CountryId,
                CreatedByUserId=model.CreatedByUserId,
                CreationDate=model.IssueDate,
                Email=model.Email,
                UpdateDate=model.LastUpdateDate,
                UpdateByUserId=model.UpdatedByUserId
            };
            // Map TbPractitioner

            var practitionerModel = new TbPractitioner
            {
                CreatedByUserId = model.CreatedByUserId,
                CreatedDate=model.IssueDate,
                Id= model.PractitionerId,
                PersonId=model.PersonId,
                PractitionerTypeId=ViewBag.PractitionerTypeId,
                UpdatedByUserId=model.UpdatedByUserId,
                UpdatedDate=model.LastUpdateDate,
                PractitionerSpecId=model.PractitionerSpecId,
                TbPerson=null,TbPractitionerSpec=null
               
            };

            // Map TbPractitionerSpec
            var practitionerSpecModel = MapToPractitionerSpec(model);

            // Map TbPractitionerCase
            var lstPractitionerCases = model.PractitionerCases.Select(caseId => new TbPractitionerCase
            {
               CaseId= caseId,
               PractitionerId= model.PractitionerId,
               PractitionerTypeId = model.PractitionerTypeId

            }).ToList();

            return _clsPractitionerService.Save(practitionerModel, personModel, practitionerSpecModel, lstPractitionerCases);

        }

        public static TbPractitionerSpec MapToPractitionerSpec(PractitionerEditViewModel model)
        {
            var practitionerSpecModel = new TbPractitionerSpec();

            model.PractitionerTypeId = 1;
            switch (model.PractitionerTypeId)
            {
                case 1: // Regulator
                    practitionerSpecModel.RegulatorSubscriptionType = (Enums.SubscriptionTypeEnum)model.SubscriptionTypeId;
                    practitionerSpecModel.RegulatorSubscriptionWay = (Enums.SubscriptionWayEnum)model.SubscriptionWayId;
                    practitionerSpecModel.RegulatorMembershipNumber = model.RegulatorMembership;
                    break;

                case 2: // Sharia
                    practitionerSpecModel.ShariaSubscriptionType = (Enums.SubscriptionTypeEnum)model.SubscriptionTypeId;
                    practitionerSpecModel.ShariaSubscriptionWay = (Enums.SubscriptionWayEnum)model.SubscriptionWayId;
                    practitionerSpecModel.ShariaLicenseNubmer = model.ShariaLicenseNumber;
                    break;

                case 3: // Judger
                    practitionerSpecModel.JudgerSubscriptionType = (Enums.SubscriptionTypeEnum)model.SubscriptionTypeId;
                    practitionerSpecModel.JudgerSubscriptionWay = (Enums.SubscriptionWayEnum)model.SubscriptionWayId;
                    break;

                case 4: // Expert
                    practitionerSpecModel.ExpertSubscriptionType = (Enums.SubscriptionTypeEnum)model.SubscriptionTypeId;
                    practitionerSpecModel.ExpertSubscriptionWay = (Enums.SubscriptionWayEnum)model.SubscriptionWayId;
                    break;

                default:
                    throw new ArgumentException("Invalid PractitionerTypeId", nameof(model.PractitionerTypeId));
            }

            return practitionerSpecModel;
        }

    }

}
