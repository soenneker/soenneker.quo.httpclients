using Soenneker.Quo.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Quo.HttpClients.Tests;

[Collection("Collection")]
public sealed class OpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IQuoOpenApiHttpClient _httpclient;

    public OpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IQuoOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
