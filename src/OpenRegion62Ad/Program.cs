using OpenRegion62Ad;
using OpenRegion62Ad.Configuration;
using OpenRegion62Ad.Entities;
using System.Reflection;

Version? version = Assembly.GetExecutingAssembly().GetName().Version;

Console.WriteLine($"Open Region 62 File Converter. Версия {version}");
Console.WriteLine("=============================================");

ConverterParameters? parameters = ConverterParametersParser.Parse(args);

if (parameters is null)
{
	Console.WriteLine();
	Console.WriteLine("Использование:");
	Console.WriteLine("  --uri <address> - адрес источника;");
	Console.WriteLine("  --file <filename> - путь к конечному файлу;");

    return;
}
var cancellationToken = CancellationToken.None;
MappingConfiguration mapping = ConfigurationLoader.GetMappingConfiguration();
IReadOnlyCollection<EventEntity>? data = await JsonDownloader.GetDataAsync(parameters.Uri, cancellationToken);

if (data is null)
{
    Console.WriteLine("Error: Нет данных.");
	return;
}

await OpenRegionConverter.SaveAsync(data, mapping, parameters.FileName, cancellationToken);

Console.WriteLine($"Данные сохранены в файл {parameters.FileName}.");
