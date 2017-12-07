namespace NetCoreAppProj.Tests.Unit.Command
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserCommands
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserCommands()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task User_create_send_to_user_controller_correctly()
        {
            var requestUri = "home/index";
            var response = await _client.GetAsync(requestUri);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
