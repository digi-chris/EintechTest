using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EintechTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EintechTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}