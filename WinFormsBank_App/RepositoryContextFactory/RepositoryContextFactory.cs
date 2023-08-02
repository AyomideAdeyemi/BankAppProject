using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_Repository.Data;

namespace WinFormsBank_App.RepositoryContextFactory
{
    
        public class RepositoryContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("BankApp-Repository"));
                return new AppDbContext(builder.Options);
            }

        
    }
    
}
