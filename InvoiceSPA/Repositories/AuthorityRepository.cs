// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorityRepository.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AuthorityRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EFCore.BulkExtensions;

    using InvoiceSPA.Data;
    using InvoiceSPA.Entities;
    using InvoiceSPA.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    /// <summary>
    /// The authority repository.
    /// </summary>
    public class AuthorityRepository : IAuthorityRepository
    {
        /// <summary>
        /// The application db context.
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorityRepository"/> class.
        /// </summary>
        /// <param name="applicationDbContext">
        /// The application db context.
        /// </param>
        public AuthorityRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <inheritdoc />
        /// <summary>
        /// The add.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Add(Authority authority)
        {
            this.applicationDbContext.Authorities.Add(authority);
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Update(Authority authority)
        {
            this.applicationDbContext.Authorities.Update(authority);
        }

        /// <inheritdoc />
        /// <summary>
        /// The remove.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Remove(Authority authority)
        {
            this.applicationDbContext.Authorities.Remove(authority);
        }

        /// <inheritdoc />
        /// <summary>
        /// The bulk remove.
        /// </summary>
        /// <param name="authorities">
        /// The authorities.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task BulkRemove(List<Authority> authorities)
        {
            await this.applicationDbContext.BulkDeleteAsync(authorities);
        }

        /// <inheritdoc />
        /// <summary>
        /// The find related invoices.
        /// </summary>
        /// <param name="authority">
        /// The authority.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<List<Authority>> FindRelatedInvoices(string authority)
        {
            return await this.applicationDbContext.Authorities
                        .Include(x => x.Invoice)
                        .ThenInclude(y => y.InvoiceItems)
                        .Where(x => x.Name.Equals(authority, StringComparison.OrdinalIgnoreCase))
                        .ToListAsync();
        }

        /// <inheritdoc />
        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task SaveChanges()
        {
            await this.applicationDbContext.SaveChangesAsync();
        }
    }
}
