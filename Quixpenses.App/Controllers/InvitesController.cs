using Microsoft.AspNetCore.Mvc;
using Quixpenses.App.Services.Invites;

namespace Quixpenses.App.Controllers;

// TODO: Authorization

[Route("api/[controller]")]
[ApiController]
public class InvitesController : ControllerBase
{
    private readonly IInvitesServices _invitesServices;

    public InvitesController(IInvitesServices invitesServices)
    {
        _invitesServices = invitesServices;
    }

    [HttpPost]
    public async Task<IActionResult> CreateInviteAsync()
    {
        var result = await _invitesServices.CreateInviteAsync();
        return Ok(result);
    }
}