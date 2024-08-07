﻿using Microsoft.EntityFrameworkCore;

namespace MagazynAPI.Entities
{
    public class MagazynDbContext : DbContext
    {
        private const string _connectionString =
            "Server=localhost;Database=Magazyn;Trusted_Connection=True;TrustServerCertificate=true;";

        public DbSet<Storage> Storages { get; set; }
        public DbSet<Address>Addresses { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Storage>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Item>()
                .Property(d => d.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
