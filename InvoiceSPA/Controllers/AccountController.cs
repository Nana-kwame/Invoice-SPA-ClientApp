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
    using System.Threading.Tasks;

    using InvoiceSPA.Models;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The account controller.
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
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
        public bool Login([FromBody] LoginInput loginInput)
        {
            return loginInput.Password == "password" && loginInput.Username == "mock";
        }

        public bool Register()
        {
            return true;
        }
    }
}
