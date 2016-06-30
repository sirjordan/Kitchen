using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchen.Web.Models
{
    public class NavViewModel
    {
        public string Text { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public NavViewModel()
        {
            this.Action = "Index";
        }
    }
}