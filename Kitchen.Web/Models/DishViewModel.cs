using System.ComponentModel.DataAnnotations;

namespace Kitchen.Web.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Продукт")]
        [Required(ErrorMessage = "Задължително поле")]
        public string Name { get; set; }

        [Display(Name = "Цена (лв.)")]
        [Required(ErrorMessage = "Задължително поле")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Задължително поле")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        public int CategoryId { get; set; }

        [Display(Name = "Алергени")]
        public string Allergens { get; set; }

        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; }

        [Display(Name = "Тегло (гр.)")]
        [Required(ErrorMessage = "Задължително поле")]
        [Range(0, double.MaxValue)]
        public int Weight { get; set; }
    }
}
