using Microsoft.Extensions.Configuration;

namespace OpenRegion62Ad.Configuration;

internal class ConfigurationLoader
{
	private static readonly IConfigurationRoot _configuration;

	static ConfigurationLoader()
	{
		var configurationBuilder = new ConfigurationBuilder();

		_configuration = configurationBuilder
			.AddJsonFile("appsettings.json", false, false)
			.Build();
	}

	public static MappingConfiguration GetMappingConfiguration()
	{
		var options = new MappingConfiguration
		{
			Areas = [],
			Categories = []
		};

		_configuration.Bind(MappingConfiguration.SECTION_NAME, options);

		return options;
	}

}
