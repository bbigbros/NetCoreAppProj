namespace NetCoreAppProj.Tests.Unit.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using AutoFixture;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetCoreAppProj.Controllers;
    using NetCoreAppProj.Models.Board;
    using Newtonsoft.Json;

    [TestClass]
    public class PostController_specs : Given_test_server
    {
        [TestMethod]
        public void Sut_inherits_controller()
        {
            typeof(PostController).BaseType.Should().Be(typeof(Controller));
        }

        [TestMethod]
        public async Task When_null_post_sends_then_returns_BadRequest()
        {
            var requestUri = "post/create";
            var content = new StringContent(
                JsonConvert.SerializeObject(null),
                Encoding.UTF8,
                "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_vaild_post_sends_then_returns_Ok()
        {
            var requestUri = "post/create";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = fixture.Create<string>(),
                Content = fixture.Create<string>(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };
            var content = new StringContent(
                JsonConvert.SerializeObject(post),
                Encoding.UTF8,
                "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
