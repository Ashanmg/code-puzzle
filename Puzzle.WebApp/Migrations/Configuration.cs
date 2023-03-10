namespace Puzzle.WebApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Puzzle.WebApp.Infrastructure;
    using Puzzle.WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // add some data to the todo list.
            List<Todo> todoList = new List<Todo>();

            todoList.Add(new Todo() { Description = "Seed Data", CreatedDate = DateTime.Now });
            todoList.Add(new Todo() { Description = "Seed Data", CreatedDate = DateTime.Now });
            todoList.Add(new Todo() { Description = "Seed Data", CreatedDate = DateTime.Now });

            context.Todos.AddRange(todoList);
            context.SaveChanges();
        }
    }
}
