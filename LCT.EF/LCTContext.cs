using LCT.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LCT.EF
{
    public class LCTContext : DbContext
    {

        public DbSet <Makbuz> Makbuzlar { get; set; }
        public DbSet <Users> Users { get; set; }
        public LCTContext()
        {
        }
        public LCTContext(DbContextOptions<LCTContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Server=LAPTOP-STS14AS8; Database=LctStaj_21; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

          
            modelBuilder.Entity<Makbuz>(entity =>
            {
                entity.ToTable("makbuzlar");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Date).HasColumnType("datetime");
                entity.Property(x => x.Description).HasMaxLength(400);

            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.Id);
               

            });
        }
    }
}
