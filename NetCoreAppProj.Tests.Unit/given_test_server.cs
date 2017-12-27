namespace NetCoreAppProj.Tests.Unit
{
    using System.Net.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NetCoreAppProj.Models;

    public class Given_test_server
    {
        protected TestServer Server { get; private set; }

        protected HttpClient Client { get; private set; }

        public Given_test_server()
        {
            IWebHostBuilder builder = new WebHostBuilder()
                .ConfigureServices(ConfigureServiceDouble)
                .UseStartup<Startup>();
            Server = new TestServer(builder);
            Client = Server.CreateClient();
        }

        public void ConfigureServiceDouble(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NetCoreAppProj;Trusted_Connection=True;"));
        }
    }
}
