using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Nightpike.Api.Models;

[Table("events")]
public class Event
{
    [Column("id")]
    public long Id { get; set; }

    [Column("occurred_at")]
    public DateTimeOffset OccurredAt { get; set; }

    [Column("received_at")]
    public DateTimeOffset ReceivedAt { get; set; }

    [Column("event_type")]
    public string EventType { get; set; } = "";

    [Column("username")]
    public string? Username { get; set; }

    [Column("source_ip")]
    public IPAddress SourceIp { get; set; } = IPAddress.None;

    [Column("invalid_user")]
    public bool InvalidUser { get; set; }

    [Column("host")]
    public string Host { get; set; } = "";

    [Column("raw_line")]
    public string RawLine { get; set; } = "";
}