namespace NetCoreAppProj.Tests.Unit.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetCoreAppProj.Controllers;
    using NetCoreAppProj.Models.Identity;
    using Newtonsoft.Json;

    [TestClass]
    public class LoginController_specs : given_test_server
    {
        [TestMethod]
        public void sut_inherits_controller()
        {
            typeof(LoginController).BaseType.Should().Be(typeof(Controller));
        }

        [TestMethod]
        public async Task when_create_user_send_then_returns_badrequest()
        {
            var user = new User(Guid.NewGuid(), "a", "Dd", "ddd");
            var requestUri = "login/create-user";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task when_create_user_sends_then_sends_user_info_correctly()
        {
            var user = new User(Guid.NewGuid(), "Jaeryong", "jr.im@ohmylab.com", "1234");
            var requestUri = "login/create-user";
            var content = new StringContent(
                JsonConvert.SerializeObject(user),
                Encoding.UTF8,
                "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };

            var response = await Client.SendAsync(request);
        }
    }
}
