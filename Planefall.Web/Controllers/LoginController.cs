namespace Planefall.Controllers
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using ViewModels.User;

    public class LoginController : BaseController
    {
        private readonly SignInManager<PlanefallUser> signInManager;

        public LoginController(SignInManager<PlanefallUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalConstants.LoginModalErrorKey] = NotificationMessages.WrongPassword;
                return this.RedirectToAction("Index");
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
                model.RememberMe, false);

            if (!result.Succeeded)
            {
                this.TempData[GlobalConstants.LoginModalErrorKey] = NotificationMessages.WrongPassword;
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}