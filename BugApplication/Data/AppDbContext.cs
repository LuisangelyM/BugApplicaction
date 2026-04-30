using BugApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BugApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bug> Bugs { get; set; }

        // Mantenemos esto por si acaso, pero la conexión principal irá en Program.cs
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost; Database=BugTrackerDB;Integrated Security=True;TrustServerCertificate=True");
            }
        }
    }
}