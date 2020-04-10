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
                    Group group = new Group { Name = "Test Group" };
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

        [Fact]
        public async void AddPerson()
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
                    Group group = new Group { Name = "Test Group" };
                    context.Groups.Add(group);
                    context.SaveChanges();
                }

                Group testGroup;
                using (var context = new DataContext(options))
                {
                    testGroup = await context.Groups.FirstAsync();
                    Person person = new Person { FirstName = "First", MiddleName = "Middle", LastName = "Last", GroupId = testGroup.Id };
                    context.People.Add(person);
                    context.SaveChanges();
                }

                using (var context = new DataContext(options))
                {
                    Person person = await context.People.FirstAsync();
                    Assert.Equal("First", person.FirstName);
                    Assert.Equal("Middle", person.MiddleName);
                    Assert.Equal("Last", person.LastName);
                    Assert.Equal(testGroup.Id, person.GroupId);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
