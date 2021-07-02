using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valley.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<UserData> UsersData { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>()
                .HasOne(u => u.UserDate)
                .WithMany(p => p.Points)
                .HasForeignKey(u => u.UserDateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
