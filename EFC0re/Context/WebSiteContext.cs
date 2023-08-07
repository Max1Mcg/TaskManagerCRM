using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFC0re
{
    public partial class WebSiteContext : DbContext
    {
        public WebSiteContext()
        {
        }

        public WebSiteContext(DbContextOptions<WebSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["WebSiteDB"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>(entity =>
            {
                entity.HasKey(e => e.Iddata)
                    .HasName("Data_pkey");

                entity.Property(e => e.Iddata)
                    .HasColumnName("iddata")
                    .ValueGeneratedNever();

                entity.Property(e => e.CpuLoading).HasColumnName("CPU_loading");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Period).HasColumnName("period");

                entity.Property(e => e.RamLoading).HasColumnName("RAM_loading");

                entity.Property(e => e.Rpc).HasColumnName("RPC");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.Idperiod)
                    .HasName("Settings_pkey");

                entity.Property(e => e.Idperiod)
                    .HasColumnName("idperiod")
                    .ValueGeneratedNever();

                entity.Property(e => e.Period).HasColumnName("period");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
