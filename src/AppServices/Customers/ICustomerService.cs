﻿using GaEpd.AppLibrary.Pagination;
using MyApp.AppServices.Customers.Dto;

namespace MyApp.AppServices.Customers;

public interface ICustomerService : IDisposable
{
    // Customer read
    Task<IPaginatedResult<CustomerSearchResultDto>> SearchAsync(
        CustomerSearchDto spec, PaginatedRequest paging, CancellationToken token = default);

    Task<CustomerViewDto?> FindAsync(Guid id, CancellationToken token = default);
    Task<CustomerSearchResultDto?> FindBasicInfoAsync(Guid id, CancellationToken token = default);

    // Customer write
    Task<Guid> CreateAsync(CustomerCreateDto resource, CancellationToken token = default);
    Task<CustomerUpdateDto?> FindForUpdateAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(Guid id, CustomerUpdateDto resource, CancellationToken token = default);
    Task DeleteAsync(Guid id, string? deleteComments, CancellationToken token = default);
    Task RestoreAsync(Guid id, CancellationToken token = default);

    // Contacts
    Task<Guid> AddContactAsync(ContactCreateDto resource, CancellationToken token = default);
    Task<ContactViewDto?> FindContactAsync(Guid contactId, CancellationToken token = default);
    Task<ContactUpdateDto?> FindContactForUpdateAsync(Guid contactId, CancellationToken token = default);
    Task UpdateContactAsync(Guid contactId, ContactUpdateDto resource, CancellationToken token = default);
    Task DeleteContactAsync(Guid contactId, CancellationToken token = default);
}
