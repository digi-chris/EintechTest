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
                Group RedDwarf = context.Groups.Where(g => g.Name == "Red Dwarf").First<Group>();
                Group HeartOfGold = context.Groups.Where(g => g.Name == "Heart of Gold").First<Group>();

                context.People.Add(new Person { FirstName = "David", MiddleName = "Dave", LastName = "Lister", GroupId = RedDwarf.Id });
                context.People.Add(new Person { FirstName = "Arnold", MiddleName = "Judas", LastName = "Rimmer", GroupId = RedDwarf.Id });
                context.People.Add(new Person { FirstName = "Arthur", MiddleName = "Philip", LastName = "Dent", GroupId = HeartOfGold.Id });
                context.People.Add(new Person { FirstName = "Ford", MiddleName = "", LastName = "Prefect", GroupId = HeartOfGold.Id });
                context.People.Add(new Person { FirstName = "Zaphod", MiddleName = "", LastName = "Beeblebrox", GroupId = HeartOfGold.Id });
                context.SaveChanges();
            }
        }
    }
}
