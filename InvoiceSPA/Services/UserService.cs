namespace InvoiceSPA.Services
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using InvoiceSPA.Data;
    using InvoiceSPA.Entities;
    using InvoiceSPA.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class UserService
    {
        /// <summary>
        /// Db reference
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext;

        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public UserService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.applicationDbContext = applicationDbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="uiRegister"></param>
        /// <returns></returns>
        public async Task<bool> Register(UiRegister uiRegister)
        {
            var password = CreatePassword(uiRegister.Password);

            var user = new ApplicationUser
            {
                FirstName = uiRegister.FirstName,
                LastName = uiRegister.LastName,
                PhoneNumber = uiRegister.PhoneNumber,
                HashedPassword = password.HashedPassword,
                Salt = password.Salt,
                Username = uiRegister.Username
            };

            this.applicationDbContext.ApplicationUsers.Add(user);
            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        public async Task<bool> Login(LoginInput loginInput)
        {
            var user = await this.applicationDbContext.ApplicationUsers.FirstOrDefaultAsync(
                           x => x.Username == loginInput.Username);

            if (user == null)
            {
                return false;
            }

           var valid = VerifyPassword(loginInput.Password, user.HashedPassword, user.Salt);

           if (!valid)
           {
               return false;
           }

           var claims = new List<Claim>
           {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim("username", user.Username),
           };

           var claimsIdentity = new ClaimsIdentity(
               claims, CookieAuthenticationDefaults.AuthenticationScheme);

           var authProperties = new AuthenticationProperties
           {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
           };

           await this.httpContextAccessor.HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               authProperties);

           return true;
        }

        /// <summary>
        /// Create hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private PasswordHash CreatePassword(string password)
        {
            var saltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2892DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2892DeriveBytes.GetBytes(256));

            return new PasswordHash
            {
                HashedPassword = hashPassword,
                Salt = salt
            };
        }

        /// <summary>
        /// Verify password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedPassword"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        private bool VerifyPassword(string password, string storedPassword, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2892DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);

            var passwordHash = Convert.ToBase64String(rfc2892DeriveBytes.GetBytes(256));

            return passwordHash == storedPassword;
        }

    }
}
