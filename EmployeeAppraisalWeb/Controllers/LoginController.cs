using EmployeeAppraisalWeb.Models.User;
using EmployeeAppraisalWeb.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAppraisalWeb.Controllers
{
    public class LoginController : Controller
    {

        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            this._userService = userService;
        }


        public IActionResult LoginPage()
        {
            return View("Index");
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAction(UserLoginViewModel viewModel)
        {
            if(ModelState.IsValid) 
            {
                try
                {
                    var ticket = _userService.SetLogin(viewModel);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ticket.Principal,
                        ticket.Properties
                    );

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e) 
                {
                    ViewBag.Message = e.Message;
                }
            }

            return View("Index", "Login");
        }
    }
}
