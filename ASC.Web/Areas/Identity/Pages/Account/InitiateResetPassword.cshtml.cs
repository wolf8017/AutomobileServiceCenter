using System.Threading.Tasks;
using ASC.Utilities;
using ASC.Web.Models;
using ASC.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASC.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class InitiateResetPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public InitiateResetPasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Find User
            var userEmail = HttpContext.User.GetCurrentUserDetails().Email;
            var user = await _userManager.FindByEmailAsync(userEmail);
            // Generate User code
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new {
                        userId = user.Id,
                        code = code
                    },
                    protocol: Request.Scheme);
            // Send Email
            await _emailSender.SendEmailAsync(userEmail, "Reset Password",
            $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
            // If we got this far, something failed, redisplay form
            return RedirectToPage("./ResetPasswordEmailConfirmation");
        }
    }
}
