using System;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Web.Models
{
    public class OrderViewModel
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = "Задължително поле")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Телефон за връзка")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Адрес на доставката")]
        public string Address { get; set; }

        [Display(Name = "Поръчана")]
        [DisplayFormat(DataFormatString = ConfigurationManager.Settings.DataBindDateTimeFormat)]
        public DateTime PurchasedAt { get; set; }

        public CartViewModel Cart { get; set; }
    }
}
