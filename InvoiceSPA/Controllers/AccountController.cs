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
    using System.Threading.Tasks;

    using InvoiceSPA.Models;
    using InvoiceSPA.Services;

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public AccountController(UserService userService)
        {
            this.userService = userService;
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
    }
}
