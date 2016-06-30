using Kitchen.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kitchen.Web.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult Menu()
        {
            // What menu item is selected
            string[] requestFragments = Request.Url.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string invoker = null;
            if (requestFragments.Count() > 0)
            {
                invoker = requestFragments[0].Trim();
            }
            
            List<NavViewModel> navigationItems = new List<NavViewModel>()
            {
                new NavViewModel() { Text= "Меню", Controller = "Menu" },
                new NavViewModel() { Text= "Галерия", Controller = "Gallery" },
                new NavViewModel() { Text= "Заявки", Controller = "Requests" },
                new NavViewModel() { Text= "Резервации", Controller = "Reservations" },
                new NavViewModel() { Text= "Намери ни", Controller = "Contacts" },
            };

            ViewBag.SelectedMenuItem = invoker;
            return PartialView("Navigation", navigationItems);
        }
    }
}