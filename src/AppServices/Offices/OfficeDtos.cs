﻿namespace MyAppRoot.AppServices.Offices;

public class OfficeViewDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool Active { get; init; }
}

public class OfficeCreateDto
{
    public string Name { get; init; } = string.Empty;
}

public class OfficeUpdateDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public bool Active { get; init; }
}
