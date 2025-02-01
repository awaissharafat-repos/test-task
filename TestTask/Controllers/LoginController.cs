using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;
using TestTask.Models.DTOs;
using TestTask.Models.ViewModels;


namespace TestTask.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;
        private readonly ISessionManager _sessionManager;
        private LoginViewModel loginViewModel;

        public LoginController(ILogger<LoginController> logger, ISessionManager sessionManager, ILoginService loginservice)
        {
            _logger = logger;
            _sessionManager = sessionManager;
            _loginService = loginservice;
            loginViewModel = new LoginViewModel();
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserDetailDTO result = _loginService.AuthenticateUser(loginViewModel.Email, loginViewModel.Password);
                if (result != null)
                {
                    if (!result.IsActive)
                    {
                        ViewBag.ErrorMessage = "Inactive user.";
                    }
                    else
                    {
                        // Set session values
                        _sessionManager.SetUserId(result.UserId);
                        _sessionManager.SetUserDetailId(result.UserDetailId);
                        _sessionManager.SetUserName(result.FirstName + " " + result.LastName);

                        // Create claims
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()),
                            new Claim(ClaimTypes.Name, result.Email),
                            new Claim("UserDetailId", result.UserDetailId.ToString())
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        // Sign in the user
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        return RedirectToAction("AllProducts", "Products");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid user or password.";
                }
            }

            // If we got this far, something failed; redisplay form
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            // Clear user-related session data
            _sessionManager.SetUserId(0); // Or use appropriate method to clear user ID
            _sessionManager.SetUserDetailId(0); // Clear user detail ID
            _sessionManager.SetUserName(string.Empty); // Clear username

            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Optionally log the logout action
            // _logger.LogInformation("User logged out.");

            // Redirect to the return URL or default to the login page
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToAction("Login", "Login"); // Redirect to login action
        }
    }
}
