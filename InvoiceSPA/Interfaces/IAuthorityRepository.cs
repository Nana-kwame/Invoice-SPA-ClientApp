// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthorityRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The AuthorityRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InvoiceSPA.Entities;

    /// <summary>
    /// The AuthorityRepository interface.
    /// </summary>
    public interface IAuthorityRepository
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="authority">
        /// The authority.
        /// </param>       
        void Add(Authority authority);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="authority">
        /// The authority.
        /// </param>  
        void Update(Authority authority);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="authority">
        /// The authority.
        /// </param>
        void Remove(Authority authority);

        /// <summary>
        /// The bulk remove.
        /// </summary>
        /// <param name="authorities">
        /// The authorities.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task BulkRemove(List<Authority> authorities);

        /// <summary>
        /// The find related invoices.
        /// </summary>
        /// <param name="authority">
        /// The authority.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<Authority>> FindRelatedInvoices(string authority);

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveChanges();
    }
}
