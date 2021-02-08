using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace ArandaSolft.Identity.IntegrationTests.API
{
    public class Initialization
    {
        public TestServer TestServer { get; }

        public Initialization()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder
                .UseStartup<Startup>()
                .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build());
                

            TestServer = new TestServer(webBuilder);
        }
    }
}
