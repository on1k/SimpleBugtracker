namespace Bugtracker.Data.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bugtracker.Data.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bugtracker.Data.MyDbContext context)
        {
            context.Positions.AddOrUpdate(x => x.PositionID,
                new Position { PositionID = 1, Title = "Старший менеджер" },
                new Position { PositionID = 2, Title = "Менеджер" },
                new Position { PositionID = 3, Title = "Тестировщик" });

            context.Statuses.AddOrUpdate(x => x.StatusID,
                new Status { StatusID = 1, Title = "Завершено" },
                new Status { StatusID = 2, Title = "В обработке" });

            context.Persons.AddOrUpdate(x => x.PersonID,
                new Person { PersonID = 1, Phone = "+7698521456", PositionID = 1, Name = "Иван", FirstName = "Иванов", LastName = "Иванович" },
                new Person { PersonID = 2, Phone = "+7966321458", PositionID = 2, Name = "Илья", FirstName = "Пупскин", LastName = "Адольфович" },
                new Person { PersonID = 3, Phone = "+7962144544", PositionID = 3, Name = "Тимофей", FirstName = "Тимкин", LastName = "Тимофеевич" },
                new Person { PersonID = 4, Phone = "+7987521421", PositionID = 1, Name = "Степан", FirstName = "Степанов", LastName = "Степанович" },
                new Person { PersonID = 5, Phone = "+7954122578", PositionID = 1, Name = "Дмитрий", FirstName = "Сопов", LastName = "Афанасьевич" });

            var person1 = context.Persons.Find(1);
            var person2 = context.Persons.Find(2);
            var person3 = context.Persons.Find(3);
            var person4 = context.Persons.Find(4);
            var person5 = context.Persons.Find(5);

            context.Tickets.AddOrUpdate(x => x.TicketID,
                new Ticket { TicketID = 1, Description = "Не работает кнопка на главной странице", CreatedDate = DateTime.Now.AddHours(4), Person = person1, StatusID = 2 },
                new Ticket { TicketID = 2, Description = "Закончилась бумага в офисе", CreatedDate = DateTime.Now.AddHours(5), Person = person2, StatusID = 1 },
                new Ticket { TicketID = 3, Description = "Не отображается баннер", CreatedDate = DateTime.Now.AddHours(2), Person = person3, StatusID = 2 },
                new Ticket { TicketID = 4, Description = "Кофемашина сломалась", CreatedDate = DateTime.Now.AddHours(1), Person = person4, StatusID = 2 },
                new Ticket { TicketID = 5, Description = "Корзина покупателя не работает", CreatedDate = DateTime.Now.AddHours(24), Person = person5, StatusID = 2 },
                new Ticket { TicketID = 6, Description = "Закончились чернила в принтере", CreatedDate = DateTime.Now.AddHours(44), Person = person2, StatusID = 1 },
                new Ticket { TicketID = 7, Description = "Шаблоны не корректно отображаются", CreatedDate = DateTime.Now.AddHours(23), Person = person2, StatusID = 2 },
                new Ticket { TicketID = 8, Description = "Обратная связь не работает", CreatedDate = DateTime.Now.AddHours(12), Person = person3, StatusID = 1 },
                new Ticket { TicketID = 9, Description = "Ошибка доступа к личному кабинету", CreatedDate = DateTime.Now.AddHours(15), Person = person4, StatusID = 2 },
                new Ticket { TicketID = 10, Description = "Патч 4.3.21 не устанавливается", CreatedDate = DateTime.Now.AddHours(41), Person = person4, StatusID = 1 },
                new Ticket { TicketID = 11, Description = "Сайт упал", CreatedDate = DateTime.Now.AddHours(26), Person = person5, StatusID = 2 },
                new Ticket { TicketID = 12, Description = "Заел замок в кладовке, помогите!", CreatedDate = DateTime.Now.AddHours(1), Person = person1, StatusID = 2 }
                );

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
