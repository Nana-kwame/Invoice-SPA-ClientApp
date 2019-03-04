// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipientRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The recipient repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InvoiceSPA.Data;
    using InvoiceSPA.Entities;
    using InvoiceSPA.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    /// <summary>
    /// The recipient repository.
    /// </summary>
    public class RecipientRepository : IRecipientRepository
    {
        /// <summary>
        /// The application db context.
        /// </summary>
        private readonly ApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientRepository"/> class.
        /// </summary>
        /// <param name="applicationDbContext">
        /// The application db context.
        /// </param>
        public RecipientRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <inheritdoc />
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Add(Recipient recipient)
        {
            this.applicationDbContext.Recipients.Add(recipient);
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Update(Recipient recipient)
        {
            this.applicationDbContext.Recipients.Update(recipient);
        }

        /// <inheritdoc />
        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public void Remove(Recipient recipient)
        {
            this.applicationDbContext.Recipients.Remove(recipient);
        }

        /// <inheritdoc />
        /// <summary>
        /// The find by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<Recipient> FindById(string id)
        {
            return await this.applicationDbContext.Recipients.Include(x => x.Invoices)
                .FirstOrDefaultAsync(y => y.RecipientNumber == id);
        }

        /// <inheritdoc />
        /// <summary>
        /// The find by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<List<Recipient>> FindByName(string name)
        {
            return await this.applicationDbContext.Recipients.Include(x => x.Invoices).Where(y => y.Name.Contains(name))
                       .ToListAsync();
        }

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SaveChanges()
        {
            await this.applicationDbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        /// <summary>
        /// The get recipient count.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Int32" />.
        /// </returns>
        public int GetRecipientCount()
        {
            return this.applicationDbContext.Recipients.ToList().Count;
        }
    }
}
