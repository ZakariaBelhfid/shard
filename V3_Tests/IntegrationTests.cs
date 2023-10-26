using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Shard.Shared.Web.IntegrationTests;
using Xunit.Abstractions;

namespace V3_Tests;

public class IntegrationTests : BaseIntegrationTests<Program>
{
    public IntegrationTests(
        WebApplicationFactory<Program> factory,
        ITestOutputHelper testOutputHelper)
        : base(factory, testOutputHelper) 
    {
        
    }
    
    
    
    
}