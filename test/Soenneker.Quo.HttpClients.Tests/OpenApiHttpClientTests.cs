using Soenneker.Quo.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Quo.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenApiHttpClientTests : HostedUnitTest
{
    private readonly IQuoOpenApiHttpClient _httpclient;

    public OpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IQuoOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
