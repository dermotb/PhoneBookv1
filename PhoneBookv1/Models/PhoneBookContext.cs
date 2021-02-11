using Microsoft.EntityFrameworkCore;

namespace PhoneBookv1.Models
{
    class PhoneBookContext : DbContext
    {
        private const string connectionString =
            "Server=(localdb)\\mssqllocaldb;DataBase=PBook3;Trusted_Connection=False;";

        public DbSet<PhoneBookEntry> PhoneBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }
    }
 }
