namespace Nightpike.Api.Models;

public record CreateEventRequest(
    DateTimeOffset OccurredAt,
    string EventType,
    string? Username,
    string SourceIp,
    bool InvalidUser,
    string Host,
    string RawLine);