namespace CodingTracker.Models;

internal class CodingSession
{
    internal required int Id { get; set; }
    internal required string StartTime { get; set; }
    internal required string EndTime { get; set; }
    internal required string Duration { get; set; }
}
