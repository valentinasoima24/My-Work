using Microsoft.EntityFrameworkCore;
using VendingMachine_SV.Models;

namespace iQuest.VendingMachine.DataAccess
{
    internal class VendingMachineContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=VendingMachine.SQLite.db");
            base.OnConfiguring(options);
        }
    }
}
