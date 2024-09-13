using Aadl.Models.AccountViewModels;
using Domains.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Aadl.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser userModel = new()
                    {
                        UserName = newUserVM.UserName,
                        Email = newUserVM.Email
                    };

                    IdentityResult createResult = await userManager.CreateAsync(userModel, newUserVM.Password);

                    if (createResult.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }

                    foreach (var item in createResult.Errors)
                    {
                        if (item.Code == "DuplicateUserName")
                        {
                            ModelState.AddModelError("UserName", "اسم المستخدم مستخدم بالفعل.");
                        }
                        else if (item.Code == "DuplicateEmail")
                        {
                            ModelState.AddModelError("Email", "البريد الإلكتروني مستخدم بالفعل.");
                        }
                        else
                        {
                            ViewBag.ServerError = item.Description;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (you can log the exception details using a logging framework)
                    ViewBag.ServerError = "حدث خطأ غير متوقع. الرجاء المحاولة مرة أخرى لاحقاً.";

                    // Optionally, you can add more details to the error message if it's safe to expose it to the user
                    // ModelState.AddModelError("", ex.Message);
                }
            }

            return PartialView(newUserVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Attempt to find the user by username or email
                    ApplicationUser? userModel = await userManager.FindByNameAsync(userVM.UserName)
                                                ?? await userManager.FindByEmailAsync(userVM.UserName);

                    if (userModel != null)
                    {
                        bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);

                        if (found)
                        {
                            await signInManager.SignInAsync(user: userModel, isPersistent: userVM.RememberMe);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "كلمة السر خطاء.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "لا يوجد حساب بهذا الاسم/الايميل.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can log the exception details using a logging framework)
                ViewBag.ServerError = "حدث خطأ غير متوقع. الرجاء المحاولة مرة أخرى لاحقاً.";

                // Optionally, you can add more details to the error message if it's safe to expose it to the user
                // ModelState.AddModelError("", ex.Message);
            }

            return PartialView(userVM);
        }
    }
}
