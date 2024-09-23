namespace OpenRegion62Ad.Configuration;

internal class MappingConfiguration
{
	public const string SECTION_NAME = "Mapping";

	public required IReadOnlyCollection<AreaMapping> Areas { get; init; }
	public required IReadOnlyCollection<CategoryMapping> Categories { get; init; }
}
