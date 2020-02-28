namespace Planefall.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using ViewModels.User;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        private readonly UserManager<PlanefallUser> userManager;

        public UsersController(UserManager<PlanefallUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var allUsers = await this.userManager.Users
                .OrderBy(u => u.UserName)
                .ProjectTo<UserListingViewModel>()
                .ToArrayAsync();

            var adminIds = (await this.userManager.GetUsersInRoleAsync(GlobalConstants.AdministratorRoleName))
                .Select(u => u.Id)
                .ToHashSet();

            foreach (var user in allUsers)
            {
                if (adminIds.Contains(user.Id))
                {
                    user.IsAdmin = true;
                }
            }

            return this.View(allUsers);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteUser(string userId)
        {
            if (userId == null)
            {
                this.ShowErrorMessage(NotificationMessages.UserPromoteErrorMessage);
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                this.ShowErrorMessage(NotificationMessages.UserPromoteErrorMessage);
                return this.RedirectToAction("Index");
            }

            if (!await this.userManager.IsInRoleAsync(user, GlobalConstants.AdministratorRoleName))
            {
                await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }

            this.ShowSuccessMessage(NotificationMessages.UserPromoteSuccessMessage);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DemoteUser(string userId)
        {
            if (userId == null)
            {
                this.ShowErrorMessage(NotificationMessages.UserPromoteErrorMessage);
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                this.ShowErrorMessage(NotificationMessages.UserDemoteErrorMessage);
                return this.RedirectToAction("Index");
            }

            if (await this.userManager.IsInRoleAsync(user, GlobalConstants.AdministratorRoleName))
            {
                await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }

            this.ShowSuccessMessage(NotificationMessages.UserDemoteSuccessMessage);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (userId == null)
            {
                this.ShowErrorMessage(NotificationMessages.UserDeleteErrorMessage);
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                this.ShowErrorMessage(NotificationMessages.UserDeleteErrorMessage);
                return this.RedirectToAction("Index");
            }

            var result = await this.userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                this.ShowErrorMessage(NotificationMessages.UserDeleteErrorMessage);
                return this.RedirectToAction("Index");
            }

            this.ShowSuccessMessage(NotificationMessages.UserDeleteSuccessMessage);
            return this.RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = Mapper.Map<PlanefallUser>(model);
            user.UserName = model.Email;

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var error = string.Join('\n', result.Errors.Select(e => e.Description));
                this.ShowErrorMessage(error);
                return this.View(model);
            }

            this.ShowSuccessMessage(NotificationMessages.UserCreateSuccessMessage);
            return this.RedirectToAction("Index");
        }
    }
}