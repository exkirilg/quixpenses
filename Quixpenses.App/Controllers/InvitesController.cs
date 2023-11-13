using Microsoft.AspNetCore.Mvc;
using Quixpenses.App.Services.Invites;

namespace Quixpenses.App.Controllers;

// TODO: Authorization

[Route("api/[controller]")]
[ApiController]
public class InvitesController(
        IInvitesServices invitesServices)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInviteAsync()
    {
        var result = await invitesServices.CreateInviteAsync();
        return Ok(result);
    }
}