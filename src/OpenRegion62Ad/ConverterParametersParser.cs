namespace OpenRegion62Ad;

internal class ConverterParametersParser
{
	private const string URI_ARG = "--uri";
	private const string FILE_ARG = "--file";

	private static readonly string[] _requiredArgs = [URI_ARG, FILE_ARG];

	public static ConverterParameters? Parse(string[] args)
	{
		if (args.Length < 4)
			return null;

		if (!args.All(item => _requiredArgs.Contains(item)))
			return null;

		int uriIndex = Array.IndexOf(args, URI_ARG);
		int fileIndex = Array.IndexOf(args, FILE_ARG);

		return new ConverterParameters
		{
			Uri = new Uri(args[uriIndex + 1]),
			FileName = args[fileIndex + 1]
		};
	}
}
