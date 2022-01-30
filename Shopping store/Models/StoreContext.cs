using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shopping_store.Models
{
    public class StoreContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CountCarsForUser> Counts { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Car[] cars =
            {
                new Car
                {
                    Name = "Jaguar F-Type",
                    PriceDollars = 100_000,
                    UrlImage = "https://quto.ru/service-imgs/5d/e6/28/65/5de6286523f50.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    Name = "Aston Martin DBX I",
                    PriceDollars = 300_000,
                    UrlImage = "https://quto.ru/thumb/1720x0/filters:quality(75):no_upscale()/service-imgs/5d/d5/0f/e0/5dd50fe07ca1b.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 200_000,
                    Name = "Bentley Continental GT III",
                    UrlImage = "https://quto.ru/thumb/1066x0/filters:quality(75):no_upscale()/service-imgs/59/bb/82/18/59bb82188187e.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 210_000,
                    Name = "Porsche 911 Turbo",
                    UrlImage = "https://quto.ru/thumb/280x0/filters:quality(75):no_upscale()/service-imgs/5e/5e/6c/e4/5e5e6ce442b54.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 190_000,
                    Name = "Lamborghini Urus",
                    UrlImage = "https://quto.ru/thumb/280x0/filters:quality(75):no_upscale()/service-imgs/5a/26/58/24/5a265824dc476.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 320_000,
                    Name = "Mercedes-Benz G-Класс",
                    UrlImage = "https://quto.ru/thumb/280x0/filters:quality(75):no_upscale()/service-imgs/5a/b2/18/e5/5ab218e5d8ffe.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 200_000,
                    Name = "Lamborghini Aventador S",
                    UrlImage = "https://quto.ru/thumb/280x0/filters:quality(75):no_upscale()/service-imgs/5d/77/54/52/5d77545220cce.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 230_000,
                    Name = "Porsche 911 Turbo кабриолет",
                    UrlImage = "https://quto.ru/thumb/280x0/filters:quality(75):no_upscale()/service-imgs/5e/5e/6c/e4/5e5e6ce442b54.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
                new Car
                {
                    PriceDollars = 300_000,
                    Name = "Bentley Mulsanne",
                    UrlImage = "https://quto.ru/thumb/280x0/filters:quality(75):no_upscale()/service-imgs/58/18/5b/61/58185b6163847.jpeg",
                    Description = "Вслед за Miura, Islero, Countach и Urraco самая легендарная модель Lamborghini воплощает наследие исторических моделей S в новом суперспорткаре Aventador S. Эксклюзивный дизайн Lamborghini и новый двигатель V12 с невероятной мощностью 740 л.с. соединяются с совершенными технологиями модельного ряда марки, в том числе с новой системой контроля динамики LDVA (Lamborghini Dinamica Veicolo Attiva / Lamborghini Active Vehicle Dynamics)."
                },
            };
            builder.Entity<Car>().HasData(cars);
            base.OnModelCreating(builder);
        }
    }
}
