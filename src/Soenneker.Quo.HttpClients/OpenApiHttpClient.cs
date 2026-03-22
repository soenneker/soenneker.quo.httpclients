using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Quo.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Quo.HttpClients;

///<inheritdoc cref="IOpenApiHttpClient"/>
public sealed class OpenApiHttpClient : IOpenApiHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrl = "https://api.openphone.com/v1/";

    public OpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(OpenApiHttpClient), (config: _config, prodBaseUrl: _prodBaseUrl), static state =>
        {
            var apiKey = state.config.GetValueStrict<string>("Quo:ApiKey");

            return new HttpClientOptions
            {
                BaseAddress = new Uri(state.prodBaseUrl),
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    {"Authorization", apiKey},
                }
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(OpenApiHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(OpenApiHttpClient));
    }
}
