namespace OpenRegion62Ad.Entities;

internal class OrganizationEntity
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
}
