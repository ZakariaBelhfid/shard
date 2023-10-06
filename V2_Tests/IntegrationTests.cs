using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Shard.Shared.Web.IntegrationTests;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace V2_Tests
{
    public class IntegrationTests : BaseIntegrationTests<Program>
    {
        public IntegrationTests(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
        {
            
        }


        [Fact]
        public void Test1()
        {

        }
    }
}