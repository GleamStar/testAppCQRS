using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TestContext>();
            var connectionString =
                "Server=(localdb)\\mssqllocaldb;Database=TestProject;Trusted_Connection=True;MultipleActiveResultSets=true";
           // var connectionString = configuration.GetConnectionString("connectionStrings:DBConnectionString");
            builder.UseSqlServer(connectionString);
            return new TestContext(builder.Options);
        }
    }
}
