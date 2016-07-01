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
            string invoker = null;
            try
            {
                string[] requestFragments = Request.Url.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (requestFragments.Count() > 0)
                {
                    invoker = requestFragments[0].Trim();
                }
            }
            catch (Exception){ /* Invoker stays Null */ }
           
            
            List<NavViewModel> navigationItems = new List<NavViewModel>()
            {
                new NavViewModel() { Text= "Меню", Controller = "Menu" },
                new NavViewModel() { Text= "Галерия", Controller = "Gallery" },
                new NavViewModel() { Text= "Заявки", Controller = "Orders", Action = "LunchRequest" },
                new NavViewModel() { Text= "Резервации", Controller = "Reservations" },
                new NavViewModel() { Text= "Намери ни", Controller = "Contacts" },
            };

            ViewBag.SelectedMenuItem = invoker;
            return PartialView("Navigation", navigationItems);
        }
    }
}