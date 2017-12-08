namespace NetCoreAppProj.Tests.Unit
{
    using System.Net.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    public class given_test_server
    {
        protected TestServer Server { get; private set; }
        protected HttpClient Client { get; private set; }

        public given_test_server()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = Server.CreateClient();
        }
    }
}
