﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestApi.Models;

namespace TestApi.Models
{
    public partial class BakdelarDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                string path = Directory.GetCurrentDirectory();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("BakdelarDB"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public BakdelarDBContext()
        {
        }

        public BakdelarDBContext(DbContextOptions<BakdelarDBContext> options)
            : base(options)
        {
        }

        public DbSet<TestApi.Models.ProductImage> ProductImage { get; set; }

        public DbSet<TestApi.Models.Category> Category { get; set; }
    }
}
