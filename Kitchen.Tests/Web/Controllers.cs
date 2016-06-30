using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen.Web.Controllers;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using Kitchen.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen.Tests
{
    [TestClass]
    public class Controllers
    {
        [TestMethod]
        public void NavControllerHandleBlankRequestWithoutErrors()
        {
            NavController ctrl = new NavController();
            var res = ctrl.Menu();
        }

        [TestMethod]
        public void NavControllerReturnsCorrectValues()
        {
            NavController ctrl = new NavController();
            Mock<HttpContextBase> contextMoq = new Mock<HttpContextBase>();            
            contextMoq.Setup(c => c.Request.Url).Returns(new Uri("http://localhost/Contacts"));
            ctrl.ControllerContext = new ControllerContext(contextMoq.Object, new RouteData(), ctrl); 

            PartialViewResult result = ctrl.Menu();

            var model = (result.Model as IEnumerable<NavViewModel>);
            string selectedMenuItem = result.ViewData["SelectedMenuItem"] as string;
            Assert.AreEqual("Contacts", selectedMenuItem);
            Assert.IsTrue(model.Count() > 0);
        }

        [TestMethod]
        public void NavControllerReturnsCorrectValuesWithComplexRoute()
        {
            NavController ctrl = new NavController();
            Mock<HttpContextBase> contextMoq = new Mock<HttpContextBase>();
            contextMoq.Setup(c => c.Request.Url).Returns(new Uri("http://localhost/Contacts/WriteUs?somearg=42"));
            ctrl.ControllerContext = new ControllerContext(contextMoq.Object, new RouteData(), ctrl);

            PartialViewResult result = ctrl.Menu();

            var model = (result.Model as IEnumerable<NavViewModel>);
            string selectedMenuItem = result.ViewData["SelectedMenuItem"] as string;
            Assert.AreEqual("Contacts", selectedMenuItem);
            Assert.IsTrue(model.Count() > 0);
        }
    }
}
