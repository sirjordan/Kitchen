using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kitchen.Web.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Задължително поле")]
        [DisplayName("Име за контакт")]
        [StringLength(maximumLength: 200, ErrorMessage = "Максимална дължина 200 символа")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Задължително поле")]
        [DisplayName("Телефон за контакт")]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Невалиден телефонен номер")]
        [StringLength(maximumLength: 24, ErrorMessage = "Невалиден телефонен номер")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Задължително поле")]
        [DisplayName("Адрес на доставка")]
        [StringLength(maximumLength: 500, ErrorMessage = "Максимална дължина 500 символа")]
        public string Address { get; set; }
        [DisplayName("Коментар")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "Максимална дължина 500 символа")]
        public string Comments { get; set; }
    }
}