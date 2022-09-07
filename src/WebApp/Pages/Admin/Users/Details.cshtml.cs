﻿using MyAppRoot.AppServices.StaffServices;
using MyAppRoot.Domain.Identity;
using MyAppRoot.WebApp.Models;
using MyAppRoot.WebApp.Platform.RazorHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAppRoot.WebApp.Pages.Admin.Users;

public class Details : PageModel
{
    public StaffViewDto DisplayStaff { get; private set; } = default!;
    public string? OfficeName => DisplayStaff.Office?.Name;
    public IList<AppRole> Roles { get; private set; } = default!;
    public DisplayMessage? Message { get; private set; }

    public async Task<IActionResult> OnGetAsync([FromServices] IStaffAppService staffService, Guid? id)
    {
        if (id == null) return NotFound();
        var staff = await staffService.FindAsync(id.Value);
        if (staff == null) return NotFound("ID not found.");

        DisplayStaff = staff;
        Roles = await staffService.GetAppRolesAsync(DisplayStaff.Id);
        Message = TempData.GetDisplayMessage();

        return Page();
    }
}
