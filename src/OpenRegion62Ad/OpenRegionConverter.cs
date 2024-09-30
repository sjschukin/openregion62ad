using OpenRegion62Ad.Configuration;
using OpenRegion62Ad.Entities;
using OpenRegion62Ad.Serialization;
using System.Text.Json;

namespace OpenRegion62Ad;

internal class OpenRegionConverter
{
    public static async Task SaveAsync(IReadOnlyCollection<EventEntity> data, MappingConfiguration mapping, string fileName, CancellationToken cancellationToken)
    {
        var outputList = new List<EventOutputEntity>(data.Count);

        foreach (var entity in data)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int? foundEventTypeId = mapping.Categories
                .FirstOrDefault(item => item.Key == (entity.Categories.FirstOrDefault()?.Id ?? -1))?.Value;

            if (foundEventTypeId is null)
            {
                Console.WriteLine($"Error: Не найдено соответствие {nameof(EventEntity.Categories)} для объекта {nameof(EventEntity.Id)} = {entity.Id}.");
                continue;
            }

            int? foundDistrictId = mapping.Areas
                .FirstOrDefault(item => item.Key == (entity.Organization?.Id ?? -1))?.Value;

            if (foundDistrictId is null)
            {
                Console.WriteLine($"Error: Не найдено соответствие {nameof(EventEntity.Organization)} для объекта {nameof(EventEntity.Id)} = {entity.Id}.");
                continue;
            }

            var outputEntity = new EventOutputEntity
            {
                Id = entity.Id,
                Name = entity.Title,
                EventTypeId = foundEventTypeId.Value,
                DistrictId = foundDistrictId.Value,
                Location = entity.Address ?? "Undefined",
                Description = entity.Times.Any()
                    ? String.Join(", ", entity.Times
                        .Select(item => item.When)
                        .OrderBy(item => item))
                    : null,
                DisplayDateBefore = entity.Times.Any()
                    ? entity.Times
                        .Select(item => item.When)
                        .Max()
                    : null,
            };

            outputList.Add(outputEntity);
        }

        using FileStream stream = File.Create(fileName);

        await JsonSerializer.SerializeAsync(stream, outputList, ApplicationJsonSerializerOptions.Custom, cancellationToken);
    }
}
