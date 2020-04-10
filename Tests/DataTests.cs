using System;
using Xunit;
using EintechTest.Models;
using EintechTest.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class DataTests
    {
        [Fact]
        public async void AddGroup()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {

                DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new DataContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new DataContext(options))
                {
                    var group = new Group { Name = "Test Group" };
                    context.Groups.Add(group);
                    context.SaveChanges();
                }

                using (var context = new DataContext(options))
                {
                    Group group = await context.Groups.FirstAsync();
                    Assert.Equal("Test Group", group.Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
