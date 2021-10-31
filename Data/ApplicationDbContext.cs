using ApplicationCore.Entities;
using Data.Configurations;
using Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //veritabanına giderken nasıl tablo oluşacak
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);
        }
    }
}
