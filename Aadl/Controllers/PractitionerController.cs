using Aadl.Models.General;
using Aadl.Models.PractitionerViewModels;
using BusinessLib.Bl.Contract;
using Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Aadl.Controllers
{
    public class PractitionerController : Controller
    {

        private readonly ICRUD<TbPractitioner> _clsPractitioner;
        private readonly IPractitionerService<TbCaseType> _clsPractitionerServices;
        public PractitionerController(ICRUD<TbPractitioner>practitionerService01,
             IPractitionerService<TbCaseType> practitionerService02)
        {
            _clsPractitioner = practitionerService01;
            _clsPractitionerServices= practitionerService02;
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
        public IActionResult Edit(int entityId)
        {
            try
            {

                var practitioner=_clsPractitioner.GetById(entityId);

                ////map to edit model
                //PractitionerEditViewModel model = new PractitionerEditViewModel()
                //{
                //     FullName=practitioner.TbPerson.FullName,
                //     IsActive=true,
                //     LastUpdateDate=DateTime.Now,
                //     PractitionerCases=new List<int>(),
                //     PractitionerId=entityId,
                //}

                ViewBag.PractitionerCases = _clsPractitionerServices.GetAll(1);
              
                PractitionerEditViewModel model = new RegulatorEditViewModel()
                {
                    FullName = "مصعب محمود علي عطية",
                    IsActive = true,
                    PractitionerCases = new List<int>() {3},
                    PractitionerId=1,
                    PractitionerTypeId=1,
                    SubscriptionTypeId=1,
                    SubscriptionWayId=1,
                    RegulatorMembership="121312"
                    
                };
       

                ViewBag.Title = "أضافة و تعديل بيانات المزاول";
                ViewBag.SubTitle = "نظامي";

                return View(model);
            
            }
            catch (Exception ex) { 
            
                throw new ArgumentNullException(nameof(entityId));
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(PractitionerEditViewModel model)
        {
       


            return View();
        }

        [HttpPost]
        public IActionResult Save()
        {
            return View();
        }
    }
}
