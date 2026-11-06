using System.Net;
using Microsoft.AspNetCore.Mvc;
using Nightpike.Api.Data;
using Nightpike.Api.Models;

namespace Nightpike.Api.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly AppDbContext _db;

    public EventsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventRequest request)
    {
        if (!IPAddress.TryParse(request.SourceIp, out var ip))
        {
            return BadRequest(new { error = "Invalid source IP address." });
        }

        var ev = new Event
        {
            OccurredAt = request.OccurredAt.ToUniversalTime(),
            ReceivedAt = DateTimeOffset.UtcNow,
            EventType = request.EventType,
            Username = request.Username,
            SourceIp = ip,
            InvalidUser = request.InvalidUser,
            Host = request.Host,
            RawLine = request.RawLine
        };

        _db.Events.Add(ev);
        await _db.SaveChangesAsync();

        return Created($"/api/events/{ev.Id}", new { id = ev.Id });
    }
}