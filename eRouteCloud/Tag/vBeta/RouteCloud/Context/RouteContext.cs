using Microsoft.EntityFrameworkCore;
using RouteCloud.Models;
using System.ComponentModel.DataAnnotations;

namespace RouteCloud.Context
{
    public partial class RouteContext : DbContext
    {
        public RouteContext()
        {
        }

        public RouteContext(DbContextOptions<RouteContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Authenticate> Authenticate { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authenticate>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("Username")
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasMaxLength(10)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Password);

                entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasMaxLength(10)
                .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    public partial class Login
    {
        [Required]
        public string Password { get; set; }
    }
}
