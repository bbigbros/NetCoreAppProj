namespace NetCoreAppProj.Tests.Unit.Commands
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserCommands_specs : given_test_server
    {
        [TestMethod]
        public async Task User_create_send_to_user_controller_correctly()
        {
            var requestUri = "home/index";
            var response = await Client.GetAsync(requestUri);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
