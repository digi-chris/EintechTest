using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EintechTest.Models;

namespace EintechTest.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Groups.Any())
            {
                context.Groups.Add(new Group { Name = "Red Dwarf" });
                context.Groups.Add(new Group { Name = "Heart of Gold" });
                context.SaveChanges();
            }

            if (!context.People.Any())
            {
                context.People.Add(new Person { FirstName = "David", MiddleName = "Dave", LastName = "Lister" });
                context.People.Add(new Person { FirstName = "Arnold", MiddleName = "Judas", LastName = "Rimmer" });
                context.People.Add(new Person { FirstName = "Arthur", MiddleName = "Philip", LastName = "Dent" });
                context.People.Add(new Person { FirstName = "Ford", MiddleName = "", LastName = "Prefect" });
                context.People.Add(new Person { FirstName = "Zaphod", MiddleName = "", LastName = "Beeblebrox" });
                context.SaveChanges();
            }
        }
    }
}
