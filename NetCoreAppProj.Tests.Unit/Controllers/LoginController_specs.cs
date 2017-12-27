namespace NetCoreAppProj.Tests.Unit.Controllers
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetCoreAppProj.Controllers;

    [TestClass]
    public class LoginController_specs : Given_test_server
    {
        [TestMethod]
        public void Sut_inherits_controller()
        {
            typeof(LoginController).BaseType.Should().Be(typeof(Controller));
        }
    }
}
