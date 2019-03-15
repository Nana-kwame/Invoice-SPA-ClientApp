// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AccountController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using InvoiceSPA.Models;
    using InvoiceSPA.Services;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The account controller.
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        /// <summary>
        /// UserService reference
        /// </summary>
        private readonly UserService userService;

        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public AccountController(UserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="loginInput">
        /// The login input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<bool> Login([FromBody] LoginInput loginInput)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            try
            {
                return await this.userService.Login(loginInput);
            }
            catch (Exception exception)
            {
               Debug.Write($"An error occured: {exception.Message}");

               return false;
            }
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="uiRegister"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Register([FromBody] UiRegister uiRegister)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            try
            {
                return await this.userService.Register(uiRegister);
            }
            catch (Exception exception)
            {
                Debug.Write($"An error occured: {exception.Message}");

                return false;
            }
        }

        /// <summary>
        /// Validate a user
        /// </summary>
        /// <param name="validateUserInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<UiUser> ValidateUser([FromBody]ValidateUserInput validateUserInput)
        {
            if (!ModelState.IsValid)
            {
                return new UiUser();
            }

            try
            {
                return await this.userService.ValidateUser(validateUserInput);
            }
            catch (Exception exception)
            {
                Debug.Write($"An error occured: {exception.Message}");

                return new UiUser();
            }
        }

        /// <summary>
        /// Change a user password
        /// </summary>
        /// <param name="changePasswordInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> ChangePassword([FromBody]ChangePasswordInput changePasswordInput)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            try
            {
                return await this.userService.ChangePassword(changePasswordInput);
            }
            catch (Exception exception)
            {
                Debug.Write($"An error occured: {exception.Message}");

                return false;
            }
        }

        /// <summary>
        /// Check if a user is authenticated
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool IsAuthenticated()
        {
            return this.userService.Authenticated();
        }

        /// <summary>
        /// Log out a user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Logout()
        {
            await this.userService.Logout();
        }
    }
}
