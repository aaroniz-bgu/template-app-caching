﻿using GaEpd.AppLibrary.ListItems;

namespace MyApp.AppServices.Offices;

public interface IOfficeService : IDisposable
{
    Task<IReadOnlyList<OfficeViewDto>> GetListAsync(CancellationToken token = default);
    Task<IReadOnlyList<ListItem>> GetActiveListItemsAsync(CancellationToken token = default);
    Task<Guid> CreateAsync(OfficeCreateDto resource, CancellationToken token = default);
    Task<OfficeUpdateDto?> FindForUpdateAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(Guid id, OfficeUpdateDto resource, CancellationToken token = default);
}
