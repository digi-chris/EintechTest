using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EintechTest.Models;
using EFCore.ModelBuilderExtensions.Extensions;

namespace EintechTest.Data
{
    public class DataContext : DbContext
    {
        bool _isSqlLte;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (options.FindExtension<Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal.SqliteOptionsExtension>() != null)
            {
                _isSqlLte = true;
            }
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!_isSqlLte)
            {
                modelBuilder.SetSQLDefaultValues();
            }
        }
    }
}