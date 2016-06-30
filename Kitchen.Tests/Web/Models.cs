using Kitchen.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Tests.Web
{
    [TestClass]
    public class Models
    {
        [TestMethod]
        public void NavViewModelDefaultValue()
        {
            NavViewModel nav = new NavViewModel();
            Assert.AreEqual("Index", nav.Action);
        }
    }
}
