// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceService.cs" company="">
//   
// </copyright>
// <summary>
//   The invoice service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InvoiceSPA.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using InvoiceSPA.Entities;
    using InvoiceSPA.Interfaces;
    using InvoiceSPA.Models;

    /// <inheritdoc />
    /// <summary>
    /// The invoice service.
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        /// <summary>
        /// The invoice repository.
        /// </summary>
        private readonly IInvoiceRepository invoiceRepository;

        /// <summary>
        /// The recipient repository.
        /// </summary>
        private readonly IRecipientRepository recipientRepository;

        /// <summary>
        /// The authority repository.
        /// </summary>
        private readonly IAuthorityRepository authorityRepository;

        /// <summary>
        /// The invoice item repository.
        /// </summary>
        private readonly IInvoiceItemRepository invoiceItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceService"/> class.
        /// </summary>
        /// <param name="invoiceRepository">
        /// The invoice repository.
        /// </param>
        /// <param name="recipientRepository">
        /// The recipient Repository.
        /// </param>
        /// <param name="authorityRepository">
        /// The authority Repository.
        /// </param>
        /// <param name="invoiceItemRepository">
        /// The invoice Item Repository.
        /// </param>
        public InvoiceService(IInvoiceRepository invoiceRepository, IRecipientRepository recipientRepository, IAuthorityRepository authorityRepository, IInvoiceItemRepository invoiceItemRepository)
        {
            this.invoiceRepository = invoiceRepository;
            this.recipientRepository = recipientRepository;
            this.authorityRepository = authorityRepository;
            this.invoiceItemRepository = invoiceItemRepository;
        }

        /// <inheritdoc />
        /// <summary>
        /// The create invoice.
        /// </summary>
        /// <param name="createInvoiceInput">
        /// The create invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<ApiResponse> CreateInvoice(CreateInvoiceInput createInvoiceInput)
        {          
            Recipient recipient;

            if (string.IsNullOrEmpty(createInvoiceInput.RecipientNumber))
            {
                // map recipient
                recipient = new Recipient
                {
                    RecipientNumber = $"RNo.{this.recipientRepository.GetRecipientCount() + 1}",
                    Address = createInvoiceInput.Address,
                    Name = createInvoiceInput.Name
                };

                this.recipientRepository.Add(recipient);
            }
            else
            {
                recipient = await this.recipientRepository.FindById(createInvoiceInput.RecipientNumber);

                if (recipient == null)
                {
                    return new ApiResponse
                    {
                       IsSuccessful = false,
                       Message = "Recipient not found"
                    };
                }
            }         

            // map invoice
            var invoice = new Invoice
            {
                Approved = false,
                CreatedOn = DateTime.Now,
                CreatedBy = createInvoiceInput.CreatedBy,
                Title = createInvoiceInput.Title,
                Status = true,
                InvoiceNo = $"INo.{this.invoiceRepository.GetInvoiceCount() + 1}"
            };


            // map authorities
            var authorities = createInvoiceInput.Authorities.Select(x => new Authority
            {
                Name = x.Name,
                Department = x.Department,
                Approved = false
            });

            // map invoice items
            var invoiceItems = createInvoiceInput.InvoiceItems.Select(x => new InvoiceItem
            {
                Name = x.Name,
                Amount = x.Amount,
                Description = x.Description
            });

            // assign and add to database
            invoice.InvoiceItems = invoiceItems.ToList();
            invoice.Authorities = authorities.ToList();

            recipient.Invoices.Add(invoice);

            await this.recipientRepository.SaveChanges();

            return new ApiResponse
            {
                IsSuccessful = true,
                Message = "Invoice Created"
            };
        }

        /// <inheritdoc />
        /// <summary>
        /// The update invoice.
        /// </summary>
        /// <param name="updateInvoiceInput">
        /// The update Invoice Input.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<ApiResponse> UpdateInvoice(UpdateInvoiceInput updateInvoiceInput)
        {
            var invoice = await this.invoiceRepository.FindById(updateInvoiceInput.InvoiceNo);

            if (invoice == null)
            {
                return new ApiResponse
                {
                   IsSuccessful = false,
                   Message = "Invoice cannot be found"
                };
            }

            invoice.Recipient.Name = updateInvoiceInput.Name;
            invoice.Recipient.Address = updateInvoiceInput.Address; 

            invoice.UpdatedBy = updateInvoiceInput.UpdatedBy;
            invoice.LastUpdated = DateTime.Now;
            invoice.Title = updateInvoiceInput.Title;

            var authoritiesUpdateList = updateInvoiceInput.Authorities.Select(x => new Authority
            {
                Name = x.Name,
                Department = x.Department,
                Approved = false
            }).ToList();

            var removedAuthorities = new List<Authority>();

            foreach (var authority in invoice.Authorities)
            {
                if (!authoritiesUpdateList.Any(x => x.Name == authority.Name && x.Department == authority.Department))
                {
                    removedAuthorities.Add(authority);
                }
            }

            await this.authorityRepository.BulkRemove(removedAuthorities);
             
            foreach (var updateAuthority in authoritiesUpdateList) 
            {
                if (!invoice.Authorities.Any(x => x.Name == updateAuthority.Name && x.Department == updateAuthority.Department))
                {
                    invoice.Authorities.Add(updateAuthority);
                }
            }

            var removedInvoiceItems = new List<InvoiceItem>();

            var invoiceItems = updateInvoiceInput.InvoiceItems.Select(x => new InvoiceItem
            {
                Name = x.Name,
                Amount = x.Amount,
                Description = x.Description
            }).ToList();

            foreach (var item in invoice.InvoiceItems)
            {
                if (!invoiceItems.Any(x => x.Name == item.Name && x.Description == item.Description && x.Amount == item.Amount))
                {
                    removedInvoiceItems.Add(item);
                }
            }

            await this.invoiceItemRepository.BulkRemove(removedInvoiceItems);

            foreach (var invoiceItem in invoiceItems)
            {
                if (!invoice.InvoiceItems.Any(x => x.Name == invoiceItem.Name && x.Description == invoiceItem.Description && x.Amount == invoiceItem.Amount))
                {
                    invoice.InvoiceItems.Add(invoiceItem);
                }
            }

            this.invoiceRepository.Update(invoice);
            await this.invoiceRepository.SaveChanges();

            return new ApiResponse
            {
                IsSuccessful = true,
                Message = "Invoice Updated"
            };
        }

        /// <inheritdoc />
        /// <summary>
        /// The delete invoice.
        /// </summary>
        /// <param name="deleteInvoiceInput">
        /// The delete Invoice Input.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<ApiResponse> DeleteInvoice(DeleteInvoiceInput deleteInvoiceInput)
        {
            foreach (var invoiceId in deleteInvoiceInput.InvoiceIds)
            {
                var invoice = await this.invoiceRepository.FindById(invoiceId);

                if (invoice == null)
                {
                    continue;
                }

                invoice.IsDeleted = true;

                this.invoiceRepository.Update(invoice);
            }

            await this.invoiceRepository.SaveChanges();

            return new ApiResponse
            {
                IsSuccessful = true,
                Message = "Invoice Deleted"
            };
        }

        /// <inheritdoc />
        /// <summary>
        /// The track invoice.
        /// </summary>
        /// <param name="invoiceNo">
        /// The invoice No.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<UiInvoice> GetInvoice(string invoiceNo)
        {
            var invoice = await this.invoiceRepository.FindById(invoiceNo);

            if (invoice == null)
            {
                return new UiInvoice();
            }

            var uiInvoice = new UiInvoice
            {
                Title = invoice.Title,
                CreatedBy = invoice.CreatedBy,
                Approved = invoice.Approved,
                Status = invoice.Status,
                CreatedOn = invoice.CreatedOn,
                InvoiceNo = invoice.InvoiceNo,
                LastUpdated = invoice.LastUpdated,
                UpdatedBy = invoice.UpdatedBy
            };

            var invoiceItems = invoice.InvoiceItems;

            if (invoiceItems.Any())
            {
                var uiInvoiceItems = invoiceItems.Select(
                    x => new UiInvoiceItem { Name = x.Name, Amount = x.Amount, Description = x.Description });

                uiInvoice.InvoiceItems.AddRange(uiInvoiceItems);
            }

            var authorities = invoice.Authorities;

            if (authorities.Any())
            {
                var uiAuthorities = authorities.Select(
                    x => new UiAuthority
                    {
                        Name = x.Name,
                        Department = x.Department,
                        Approved = x.Approved,
                        ApprovedOn = x.ApprovedOn
                    });

                uiInvoice.Authorities.AddRange(uiAuthorities);
            }

            return uiInvoice;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get user invoice.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<UiUserInvoice> GetUserInvoices(string user)
        {
            var invoices = await this.invoiceRepository.FindByCreator(user);

            var userInvoices = new UiUserInvoice();

            if (invoices.Any())
            {
                foreach (var invoice in invoices)
                {
                    var uiInvoice = new UiInvoice
                    {
                        InvoiceNo = invoice.InvoiceNo,
                        Approved = invoice.Approved,
                        CreatedBy = invoice.CreatedBy,
                        CreatedOn = invoice.CreatedOn,
                        Title = invoice.Title,
                        LastUpdated = invoice.LastUpdated,
                        UpdatedBy = invoice.UpdatedBy,
                        Status = invoice.Status
                    };

                    var recipient = invoice.Recipient;

                    var uiRecipient = new UiRecipient
                    {
                        Name = recipient.Name,
                        Address = recipient.Address,
                        RecipientNumber = recipient.RecipientNumber
                    };

                    uiInvoice.Recipient = uiRecipient;

                    var authorities = invoice.Authorities;

                    if (authorities.Any())
                    {
                        var uiAuthorities = invoice.Authorities.Select(
                            x => new UiAuthority
                            {
                                Name = x.Name,
                                Department = x.Department,
                                Approved = x.Approved,
                                ApprovedOn = x.ApprovedOn
                            });

                        uiInvoice.Authorities.AddRange(uiAuthorities);
                    }

                    var invoiceItems = invoice.InvoiceItems;

                    if (invoiceItems.Any())
                    {
                        var uiInvoiceItems = invoiceItems.Select(
                            x => new UiInvoiceItem { Name = x.Name, Amount = x.Amount, Description = x.Description });

                        uiInvoice.InvoiceItems.AddRange(uiInvoiceItems);
                    }

                    userInvoices.InvoicesCreatedByUser.Add(uiInvoice);
                }
            }

            var relatedAuthorities = await this.authorityRepository.FindRelatedInvoices(user);

            if (relatedAuthorities.Any())
            {
                foreach (var auth in relatedAuthorities)
                {
                    var invoice = auth.Invoice;

                    var uiInvoice = new UiInvoice
                    {
                        InvoiceNo = invoice.InvoiceNo,
                        Approved = invoice.Approved,
                        CreatedBy = invoice.CreatedBy,
                        CreatedOn = invoice.CreatedOn,
                        Title = invoice.Title,
                        LastUpdated = invoice.LastUpdated,
                        UpdatedBy = invoice.UpdatedBy,
                        Status = invoice.Status
                    };

                    var recipient = invoice.Recipient;

                    var uiRecipient = new UiRecipient
                    {
                        Name = recipient.Name,
                        Address = recipient.Address,
                        RecipientNumber = recipient.RecipientNumber
                    };

                    uiInvoice.Recipient = uiRecipient;

                    var invoiceItems = invoice.InvoiceItems;

                    if (invoiceItems.Any())
                    {
                        var uiInvoiceItems = invoiceItems.Select(
                            x => new UiInvoiceItem { Name = x.Name, Amount = x.Amount, Description = x.Description });

                        uiInvoice.InvoiceItems.AddRange(uiInvoiceItems);
                    }

                    userInvoices.InvoicesApprovedByUser.Add(uiInvoice);
                }
            }

            return userInvoices;
        }

        /// <inheritdoc />
        /// <summary>
        /// The approve invoice.
        /// </summary>
        /// <param name="approveInvoiceInput">
        /// The approve invoice input.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public async Task<ApiResponse> ApproveInvoice(ApproveInvoiceInput approveInvoiceInput)
        {
            var invoice = await this.invoiceRepository.FindById(approveInvoiceInput.InvoiceId);

            if (invoice == null)
            {
                return new ApiResponse
                {
                    IsSuccessful = false,
                    Message = "Invoice not found"
                };
            }

            var authority = invoice.Authorities.FirstOrDefault(
                x => x.Name.Equals(approveInvoiceInput.Authority, StringComparison.OrdinalIgnoreCase));

            if (authority == null)
            {
                return new ApiResponse
                {
                    IsSuccessful = false,
                    Message = "Not authorised to approve"
                };
            }

            authority.Approved = approveInvoiceInput.Approve;
            authority.ApprovedOn = DateTime.Now;
            
            this.authorityRepository.Update(authority);
            await this.authorityRepository.SaveChanges();

            return new ApiResponse
            {
                IsSuccessful = true,
                Message = "Invoice approved"
            };
        }
    }
}
