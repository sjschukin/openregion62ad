using System.Text.Json.Serialization;

namespace OpenRegion62Ad.Entities;

internal class EventEntity
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public string? Address { get; init; }
    public string? Phone { get; init; }

    [JsonPropertyName("categories")]
    public required IReadOnlyCollection<CategoryEntity> Categories { get; init; }

    [JsonPropertyName("times")]
    public required IReadOnlyCollection<TimesEntity> Times { get; init; }

    [JsonPropertyName("org")]
    public OrganizationEntity? Organization { get; init; }
}
