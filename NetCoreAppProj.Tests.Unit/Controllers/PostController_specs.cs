namespace NetCoreAppProj.Tests.Unit.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using AutoFixture;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetCoreAppProj.Controllers;
    using NetCoreAppProj.Models;
    using NetCoreAppProj.Models.Board;
    using Newtonsoft.Json;

    [TestClass]
    public class PostController_specs : Given_test_server
    {
        private DbContextOptions _dbContextOptions;

        [TestInitialize]
        public void TestInitialize()
        {
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=NetCoreAppProj;Trusted_Connection=True;";

            _dbContextOptions = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;
        }

        [TestMethod]
        public void Sut_inherits_controller()
        {
            typeof(PostController).BaseType.Should().Be(typeof(Controller));
        }

        [TestMethod]
        public async Task When_null_post_sends_to_create_then_returns_BadRequest()
        {
            var requestUri = "post/postcreated";
            var content = new StringContent(
                JsonConvert.SerializeObject(null),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_vaild_post_sends_to_create_then_returns_Redirect()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = fixture.Create<string>(),
                Content = fixture.Create<string>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var content = new StringContent(
               CreateHttpBody(post),
               Encoding.UTF8,
                "application/x-www-form-urlencoded");

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

        [TestMethod]
        public async Task When_null_title_post_sends_to_create_then_return_BadRequest()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = null,
                Author = fixture.Create<string>(),
                Content = fixture.Create<string>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var content = new StringContent(
                CreateHttpBody(post),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_empty_title_post_sends_to_create_then_return_BadRequest()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = string.Empty,
                Author = fixture.Create<string>(),
                Content = fixture.Create<string>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var content = new StringContent(
                CreateHttpBody(post),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_null_author_post_sends_to_create_then_return_BadRequest()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = null,
                Content = fixture.Create<string>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var content = new StringContent(
                CreateHttpBody(post),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_empty_author_post_sends_to_create_then_return_BadRequest()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = string.Empty,
                Content = fixture.Create<string>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var content = new StringContent(
                CreateHttpBody(post),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_null_content_post_sends_to_create_then_return_BadRequest()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = fixture.Create<string>(),
                Content = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var content = new StringContent(
                CreateHttpBody(post),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_empty_content_post_sends_to_create_then_return_BadRequest()
        {
            var requestUri = "post/postcreated";
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = fixture.Create<string>(),
                Content = string.Empty,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var content = new StringContent(
                CreateHttpBody(post),
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task When_post_does_not_exists_then_delete_action_returns_NotFound()
        {
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                var lastPostId = context.Posts
                                        .OrderByDescending(p => p.CreatedAt)
                                        .FirstOrDefault();
                var requestUri = $"post/delete/{lastPostId.Id + 1}";

                var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                var response = await Client.SendAsync(request);

                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [TestMethod]
        public async Task When_invalid_id_send_to_delete_action_then_returns_BadRequest()
        {
            var requestUri = $"post/delete/{new Fixture().Create<string>()}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await Client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        private async Task<Post> GivenPost()
        {
            var fixture = new Fixture();
            var post = new Post
            {
                Title = fixture.Create<string>(),
                Author = fixture.Create<string>(),
                Content = fixture.Create<string>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                context.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        private string CreateHttpBody(Post post)
        {
            string httpBody = $"Title={post.Title}&Author={post.Author}&" +
                              $"Content={post.Content}&CreatedAt={post.CreatedAt}" +
                              $"&UpdatedAt={post.UpdatedAt}";
            return httpBody;
        }
    }
}
