using Company.Biz.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace Company.Integration.Tests.EndToEnd.Controller
{

    public partial class PingShould
    {
        public HttpClient Client { get; set; }
        public PingShould()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();
                });

            var host = hostBuilder.Start();

            Client = host.GetTestClient();
        }
    }
}
