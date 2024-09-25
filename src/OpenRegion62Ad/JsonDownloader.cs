using OpenRegion62Ad.Entities;
using System.Net.Http.Json;

namespace OpenRegion62Ad;

internal class JsonDownloader
{
	private static readonly HttpClient _client;

    static JsonDownloader()
    {
        _client = new HttpClient();
    }

	public static Task<IReadOnlyCollection<EventEntity>?> GetDataAsync(Uri requestUri, CancellationToken cancellationToken)
        => _client.GetFromJsonAsync<IReadOnlyCollection<EventEntity>>(requestUri, cancellationToken);
}
