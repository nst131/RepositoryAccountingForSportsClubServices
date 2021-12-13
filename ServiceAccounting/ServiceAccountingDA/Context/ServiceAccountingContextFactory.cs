using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ServiceAccountingDA.Context
{
    public class ServiceAccountingContextFactory : IDesignTimeDbContextFactory<ServiceAccountingContext>
    {
        public ServiceAccountingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceAccountingContext>();

            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile(@"Context/appsettings.json");
            //IConfigurationRoot config = builder.Build();
            //string connectionString = config.GetConnectionString("DefaultConnection");
            string connectionString = "Server=.\\SQLEXPRESS;Database=ServiceAccountingDatabase;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);

            return new ServiceAccountingContext(optionsBuilder.Options);
        }
    }
}
