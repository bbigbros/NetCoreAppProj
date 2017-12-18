namespace NetCoreAppProj.Tests.Unit.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetCoreAppProj.Models.Identity;

    [TestClass]
    public class User_specs
    {
        [TestMethod]
        public void Sut_has_Id_property()
        {
            typeof(User).Should().HaveProperty<Guid>("Id");
        }

        [TestMethod]
        public void Sut_has_Name_property()
        {
            typeof(User).Should().HaveProperty<string>("Username")
                .Which
                .Should()
                .BeWritable();
        }

        [TestMethod]
        public void Username_is_decorated_with_RequiredAttribute()
        {
            typeof(User).GetProperty("Username")
                .Should()
                .BeDecoratedWith<RequiredAttribute>();
        }

        [TestMethod]
        public void Sut_has_Email_property()
        {
            typeof(User).Should().HaveProperty<string>("Email")
                .Which
                .Should()
                .BeWritable();
        }

        [TestMethod]
        public void Email_is_decorated_with_RequiredAttribute()
        {
            typeof(User).GetProperty("Email")
                .Should()
                .BeDecoratedWith<RequiredAttribute>();
        }

        [TestMethod]
        public void Sut_has_Password_property()
        {
            typeof(User).Should().HaveProperty<string>("Password")
                .Which
                .Should()
                .BeWritable();
        }

        [TestMethod]
        public void Password_is_decorated_with_RequiredAttribute()
        {
            typeof(User).GetProperty("Password")
                .Should()
                .BeDecoratedWith<RequiredAttribute>();
        }
    }
}
