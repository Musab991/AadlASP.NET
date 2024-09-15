using Aadl.Models.General;
using Aadl.Models.PractitionerViewModels;
using BusinessLib.Bl.Contract;
using Domains.Models;
using Domains.Models.Identity;
using Domains.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Numerics;
using System.Text.Json;

namespace Aadl.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICRUD<TbPractitioner> _clsPractitioner;
        private readonly ISpecIncludeable _clsPractitionerSpec;
        private readonly ICRUD<TbCountry> _clsCountry;
        private readonly IPractitionerTransactional<TbPractitioner> _clsPractitionerService;
        private readonly ISpecialServices<TbCaseType> _clsSpecialServices;
        public PractitionerController(ICRUD<TbPractitioner>practitionerService01,
             IPractitionerTransactional<TbPractitioner> practitionerService, ICRUD<TbCountry> counrtyService,
             UserManager<ApplicationUser> userManagerService, IHttpContextAccessor httpContextAccessor,
             ISpecIncludeable clsPractitionerSpec, ISpecialServices<TbCaseType> clsSpecialServices)
        {
            _clsPractitioner = practitionerService01;
            _clsPractitionerService = practitionerService;
            _clsCountry = counrtyService;
            _userManager = userManagerService;
            _httpContextAccessor = httpContextAccessor;
            _clsPractitionerSpec = clsPractitionerSpec;
            _clsSpecialServices = clsSpecialServices;
        }
        public async Task<ApplicationUser?> GetCurrentUserAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                return null; // No user is logged in
            }

            return await _userManager.GetUserAsync(user); // Gets the current logged-in user
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            try
            {

                var result = _clsPractitionerSpec.GetAll(true, true, true)
                .Select(p => new PractitionerListViewModel()
                {
                    PractitionerId = p.Id,
                    CreatedDate= DateTime.Now,
                    FullName=p.TbPractitioner.TbPerson.FullName,
                    IsActive=true,
                    CreatedByUserName="None",
                    Phone=p.TbPractitioner.TbPerson.Phone,
                    PractitionerCases=
                    p.TbPractitioner.TbPractitionerCases.Select(c=>c.TbCaseType.Name).ToList(),
                    PractitionerType=(Enums.PractitionerTypeEnum)p.PractitionerTypeId,
                    SubscriptionType=p.SubscriptionType,
                    SubscriptionWay=p.SubscriptionWay
      
                    
                }).ToList();
                            

            return View(result);
            }
            catch (Exception ex)
            {

                throw new NullReferenceException();
            }

        }

        [HttpGet]
        public IActionResult Edit(int? practitionerId , Enums.PractitionerTypeEnum practitionerTypeId)
        {
            try
            {
                ViewBag.PractitionerCases = _clsSpecialServices.GetAll((int)practitionerTypeId);
                ViewBag.Countries = _clsCountry.GetAll();

                PractitionerEditViewModel model = new PractitionerEditViewModel();
                if (practitionerId == null||practitionerId==0)
                {

                    model.PractitionerType =practitionerTypeId;

                }

                else
                {
                    var practitionerSpec = _clsPractitionerSpec.GetById((int)practitionerId, (int)practitionerTypeId, true,true,true);

                    Mapper.MapPersonToPractitionerEditViewModel(model,practitionerSpec.TbPractitioner.TbPerson);
                    Mapper.MapSpecToPractitionerEditViewModel(practitionerSpec, model);
                    Mapper.MapCasesToPractitionerEditViewModel(practitionerSpec.TbPractitioner.TbPractitionerCases.ToList(), model);

                    ViewBag.Title = "أضافة و تعديل بيانات المزاول";

                    return View(model);

                }

                return View(model);

            }
            catch (Exception ex) {

                return RedirectToAction("Index");
                throw new ArgumentNullException(nameof(practitionerId));
            }
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(PractitionerEditViewModel model)
        {
            try
            {

            //I could send it with viewBag[RegulatorMemberShip]
            if (ModelState.IsValid)
                {
                    var currentUser = await GetCurrentUserAsync();
                    if (currentUser != null)
                    {
                        // Access current user's properties, e.g., currentUser.UserName
                        var userName = currentUser.UserName;

                        if (model.PractitionerId == 0)
                        {
                        }
                        else
                        {
                           
                        }


                    }
                    model.CreatedByUserId = 1;
                    model.CreatedDate= DateTime.Now;
                    model.UpdatedByUserId = 1;
                    model.LastUpdateDate = DateTime.Now;
                    SavePractitioner(model);

                    //busines layer save through ef in database transaction method...
                    // Handle the model
                    // Example: Save or update the model data
                    return RedirectToAction("List");
                }
            } catch (Exception ex) {
                return RedirectToAction("Index");

                //handle 
            }
            return View(model);

        }

        private bool SavePractitioner(PractitionerEditViewModel model)
        {
            // Map view model to entity models manually

            // Map TbPerson
            TbPerson personModel =Mapper.MapPractitionerEditViewModelToPerson(model);

            // Map TbPractitioner
            TbPractitioner practitionerModel = Mapper.MapPractitionerEditViewModelToPractitioner(model);

            // Map TbPractitionerSpec
            var practitionerSpecModel = Mapper.MapPractitionerEditViewModelToSpec(model);

            // Map TbPractitionerCase
            var lstPractitionerCases = Mapper.MapPractitionerEditViewModelToCases(model);

            return _clsPractitionerService.SaveTransaction(practitionerModel, personModel, practitionerSpecModel, lstPractitionerCases);

        }

      
    }

}
