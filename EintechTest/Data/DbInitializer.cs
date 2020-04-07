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
        }
    }
}
