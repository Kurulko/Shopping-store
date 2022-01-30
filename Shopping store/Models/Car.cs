using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping_store.Models
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Введите ссылку на картинку")]
        [Url(ErrorMessage = "Это не является ссылкой...")]
        [Display(Name = "Ссылка на фото:")]
        public string UrlImage { get; set; }

        [Required(ErrorMessage = "Введите название автомобиля")]
        [Display(Name = "Название автомобиля:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание автомобиля")]
        [Display(Name = "Описание автомобиля:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите цену автомобиля")]
        [Display(Name = "Цена автомобиля($):")]
        public int? PriceDollars { get; set; }

        public List<User> Users { get; set; }
        public List<CountCarsForUser> Counts { get; set; }
    }
}
