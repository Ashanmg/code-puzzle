using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Puzzle.WebApp.Models;
using Puzzle.WebApp.Repositories;
using Puzzle.WebApp.Repositories.Interfaces;
using Puzzle.WebApp.Services;
using Puzzle.WebApp.Services.Interfaces;

namespace Puzzle.WebApp.Infrastructure
{
    public class DependencyRegistar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register your dependencies
            builder.RegisterType<ApplicationContext>().InstancePerRequest();
            builder.RegisterType<TodoService>().As<IBaseService<Todo>>();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
        }
    }
}