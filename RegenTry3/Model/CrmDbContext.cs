using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenTry3.Model
{
    public class CrmDbContext:DbContext
    {
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Backer> Backers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<BackerProject> BackerProjects { get; set; }
        public DbSet<BackerReward> BackerRewards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         // optionsBuilder.UseSqlServer("Data Source=LAPTOP-17RK5KIM\\SQLSERVER2019;Initial Catalog=RegenCrm;Integrated Security=True");
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RegenDB;User ID=sa;Password=admin!@#123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Creator>().ToTable("Creators");
            modelBuilder.Entity<Backer>().ToTable("Backers");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Reward>().ToTable("Rewards");
            modelBuilder.Entity<BackerProject>().ToTable("BackerProjects");
            modelBuilder.Entity<BackerReward>().ToTable("BackerRewards");

            modelBuilder.Entity<Creator>().HasIndex(creator => creator.Username).IsUnique();
            modelBuilder.Entity<Backer>().HasIndex(backer => backer.Username).IsUnique();
        }


        }
}
