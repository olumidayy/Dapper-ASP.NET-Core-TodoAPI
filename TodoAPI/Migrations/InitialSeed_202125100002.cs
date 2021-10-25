using System;
using System.Collections.Generic;
using FluentMigrator;
using TodoAPI.Domain.Entities;

namespace TodoAPI.Migrations
{
    [Migration(202125100002)]
    public class Initial_202125100002 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Users");
            Delete.FromTable("Todos");
        }

        public override void Up()
        {
            List<Guid> ids = new List<Guid>{};
            List<String> names = new List<String>{"Mike", "Olumide", "Precious", "Marv", "Toyo", "Satoshi", "Ichinose", "Vanitas"};
            List<String> titles = new List<String>{"Title X", "Titte Y", "Title Z", "Title A", "Title 0"};
            for (int i = 0; i < 6; i++)
            {
                Random rnd = new Random();
                String lastname = names[rnd.Next(names.Count)];
                String firstname = names[rnd.Next(names.Count)];
                Guid id = Guid.NewGuid();
                ids.Add(id);
                Insert.IntoTable("Users")
                    .Row(new User{
                        Firstname = firstname,
                        Lastname = lastname,
                        Email = String.Format("{0}{1}@email.co", firstname, lastname),
                        Id = id
                    });
                
                for (int j = 0; j < 5; j++)
                {
                    Insert.IntoTable("Todos")
                    .Row(new TodoItem{
                        Title = titles[rnd.Next(titles.Count)],
                        Description = "Some pretty long string",
                        Status = (TodoStatus)rnd.Next(3),
                        UserId = id,
                        Id = Guid.NewGuid()
                    });
                }
            }
        }
    }
}