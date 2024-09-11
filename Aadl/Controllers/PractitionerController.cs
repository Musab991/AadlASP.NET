using Aadl.Models.General;
using Aadl.Models.PractitionerViewModels;
using BusinessLib.Bl.Contract;
using Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Numerics;
using System.Text.Json;

namespace Aadl.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly ICRUD<TbPractitioner> _clsPractitioner;
        private readonly IPractitionerService<TbCaseType> _clsPractitionerServices;
        public PractitionerController(ICRUD<TbPractitioner>practitionerService01,
             IPractitionerService<TbCaseType> practitionerService02, HttpClient httpClient)
        {
            _clsPractitioner = practitionerService01;
            _clsPractitionerServices= practitionerService02;
            _httpClient = httpClient;

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
        public async Task<IActionResult>Edit(int entityId)
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

                ViewBag.PractitionerCases = _clsPractitionerServices.GetAll(2);

                var response = await _httpClient.GetAsync("https://localhost:7055/api/Values/Countries");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse =JsonSerializer.Deserialize<ApiResponse>(content);

                // Check for errors in the API response

                if (apiResponse != null && apiResponse.Errors != null)
                {

                    var countries = JsonSerializer.Deserialize<List<TbCountry>>(apiResponse.Data.ToString());
                    if (countries != null)
                    {
                        ViewBag.Countries= countries;
                    }

                }
                else
                {

                    // Handle errors accordingly
                    ViewBag.ErrorMessages = apiResponse.Errors;
                    return View("Error"); // or handle as needed
                }

                PractitionerEditViewModel model = new PractitionerEditViewModel()
                {
                    FullName = "مصعب محمود علي عطية",
                    IsActive = true,
                    PractitionerCases = new List<int>() { 3 },
                    PractitionerId = 1,
                    PractitionerTypeId = 2,
                    SubscriptionTypeId = 1,
                    SubscriptionWayId = 1,
                    RegulatorMembership = "121312",
                    ShariaLicenseNumber = string.Empty
                };
       

                ViewBag.Title = "أضافة و تعديل بيانات المزاول";
                ViewBag.SubTitle = "نظامي";

                return View(model);
            
            }
            catch (Exception ex) {

                RedirectToAction("Index");
                throw new ArgumentNullException(nameof(entityId));
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(PractitionerEditViewModel model)
        {
            //I could send it with viewBag[RegulatorMemberShip]
            if (ModelState.IsValid) {


                // Handle the model
                // Example: Save or update the model data
                return RedirectToAction("Index");
            }
            // If the model state is invalid, return the view with the current model
            return View(model);
        }

        [HttpPost]
        public IActionResult Save()
        {
            return View();
        }
    }
}
