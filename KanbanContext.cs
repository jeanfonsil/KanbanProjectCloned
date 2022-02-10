using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanProject
{
    public class KanbanContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KanbanDb;Trusted_Connection=true;");
        }
        private static KanbanContext Instance;
        public static KanbanContext GetInstance()
        {
            if (Instance == null)
            {
                Instance = new KanbanContext();
            }
            return Instance;
        }
    }
}
