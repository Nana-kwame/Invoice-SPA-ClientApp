// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipientRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The recipient repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using InvoiceSPA.Entities;

    /// <summary>
    /// The RecipientRepository interface.
    /// </summary>
    public interface IRecipientRepository
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        void Add(Recipient recipient);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        void Update(Recipient recipient);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        void Remove(Recipient recipient);

        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Recipient> FindById(string id);

        /// <summary>
        /// The find by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<Recipient>> FindByName(string name);

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveChanges();

        /// <summary>
        /// The get recipient count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetRecipientCount(); 
    }
}