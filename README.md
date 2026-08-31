[![](https://img.shields.io/nuget/v/soenneker.quo.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.quo.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.quo.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.quo.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.quo.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.quo.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.quo.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.quo.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Quo.HttpClients

Provides a cached, authenticated `HttpClient` for Quo contacts, calls, messages, conversations, phone numbers, users, and webhooks.

## Installation

```bash
dotnet add package Soenneker.Quo.HttpClients
```

## Configuration

```json
{
  "Quo": {
    "ApiKey": "your-api-key"
  }
}
```

The default base URL is `https://api.openphone.com/v1/`; Quo continues to serve its API from the OpenPhone domain. Override it with `Quo:ClientBaseUrl` for a compatible proxy.

## Usage

```csharp
using Soenneker.Quo.HttpClients.Abstract;
using Soenneker.Quo.HttpClients.Registrars;

services.AddQuoOpenApiHttpClientAsSingleton();

IQuoOpenApiHttpClient quo = serviceProvider
    .GetRequiredService<IQuoOpenApiHttpClient>();

HttpClient client = await quo.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync(
    "users",
    cancellationToken);
response.EnsureSuccessStatusCode();
```

Quo expects the API key directly in the `Authorization` header, without a `Bearer` prefix. The provider owns the cached client; scoped provider instances use separate cache entries.
