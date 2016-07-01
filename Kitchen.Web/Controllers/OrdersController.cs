using Kitchen.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kitchen.Web.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult LunchRequest()
        {
            return View("Request");
        }
        public ActionResult Submit(OrderViewModel order)
        {
            if (order != null && ModelState.IsValid)
            {
                ViewBag.MessageSuccess = "Успешно направихте Вашата поръчка за обедно меню!";
                ViewBag.Details = "Ще се свържем с Вас на посочения телефон. \"Кухня\" Ви пожелава приятен обяд!";
            }
            else
            {
                ViewBag.MessageSuccess = "Възникна грешка при поръчката! Извиняваме се за неудобството.";
                ViewBag.Details = string.Format("За да направите поръчка се обадете не тел.: {0}.", Infrastructure.Configuration.Phone);
            }

            return View();
        }
    }
}