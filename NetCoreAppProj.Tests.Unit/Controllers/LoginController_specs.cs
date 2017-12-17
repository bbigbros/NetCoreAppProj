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
        public void Sut_inherits_controller()
        {
            typeof(LoginController).BaseType.Should().Be(typeof(Controller));
        }
    }
}
