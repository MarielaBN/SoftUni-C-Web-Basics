﻿namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SULS.Models;

    public class SULSContext : DbContext
    {
       public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Submission>().HasOne(x => x.Problem);

           modelBuilder.Entity<Submission>().HasOne(x => x.User);            

            base.OnModelCreating(modelBuilder);
        }
    }
}