using EmployeeAppraisalBusiness.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using EmployeeAppraisalWeb.Models.User;

namespace EmployeeAppraisalWeb.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        private ClaimsPrincipal GetPrincipal(UserLoginViewModel viewModel)
        {
            var claims = new List<Claim>(){
            new Claim("username", viewModel.Username)
        };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(identity);
        }


        private AuthenticationTicket GetTicket(ClaimsPrincipal principal)
        {
            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.Now,
                ExpiresUtc = DateTime.Now.AddMinutes(60),
                AllowRefresh = false
            };

            AuthenticationTicket authenticationTicket = new AuthenticationTicket(
                principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme
            );

            return authenticationTicket;
        }


        public AuthenticationTicket SetLogin(UserLoginViewModel viewModel)
        {
            var model = _userRepository.GetUsers(viewModel.Username);
            bool passwordIsMatch = BCrypt.Net.BCrypt.Verify(viewModel.Password, model.Password);

            if(!passwordIsMatch)
            {
                throw new Exception("Username or password or role is incorrect!");
            }
            else
            {
                ClaimsPrincipal principal = GetPrincipal(viewModel);
                AuthenticationTicket ticket = GetTicket(principal);
                return ticket;
            }

        }
    }
}
