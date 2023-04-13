using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PersonREST.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "";
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));

            if (Debugger.IsAttached)
            {
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b => b
                        .AddConsole()
                        .AddFilter(level => level >= LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
        }
    }
}
