using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Web.Controllers;

namespace Project.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void LoginViewTest()
        {
            //Arrange
            AccountController controller = new AccountController();

            //Act
            var result = controller.Login() as ViewResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ErrorTest()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            var result = controller.Error("custom") as ViewResult;

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void HelpDeskTest()
        {
            HomeController controller = new HomeController();

            var result = controller.Helpdesk() as RedirectResult;

            Assert.IsNotNull(result);
        }
    }
}
