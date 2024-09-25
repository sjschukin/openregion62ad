namespace OpenRegion62Ad.Entities;

internal class EventOutputEntity
{
	public required int Id { get; init; }
	public required string Name { get; init; }
	public required int EventTypeId { get; init; }
	public required int DistrictId { get; init; }
	public required string Location { get; init; }
	public DateTime? StartDate { get; init; }
	public string? Description { get; init; }
	public DateOnly? DisplayDateBefore { get; init; }
}
