using Microsoft.EntityFrameworkCore;

namespace Laba2
{
    public partial class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext() { }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }

        public static string Link() => "Data Source=LAPTOP-AFNOQ4EA\\SQLEXPRESS;Initial Catalog=Lab2_pract;Integrated Security=True";

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<ServiceRequest> ServiceRequest { get; set; }

        public virtual DbSet<Сlient> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer(Link());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(a => a.Id).HasColumnName("id");
                entity.Property(b => b.ClientId).HasColumnName("client_id");
                entity.HasOne(c => c.Сlient).WithMany(d => d.Requests).HasForeignKey(e => e.ClientId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Requests_Clients");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(a => a.Id).HasColumnName("id");
                entity.Property(b => b.Name).HasColumnName("name");
                entity.HasMany(c => c.ServiceRequest).WithOne(d => d.Service).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.HasKey(a => new { a.ServiceId, a.RequestId });
                entity.Property(b => b.ServiceId).HasColumnName("service_id");
                entity.Property(c => c.RequestId).HasColumnName("request_id");
                entity.HasOne(d => d.Request).WithMany(e => e.ServiceRequest).HasForeignKey(f => f.RequestId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_ServiceRequest_Requests");
                entity.HasOne(g => g.Service).WithMany(h => h.ServiceRequest).HasForeignKey(i => i.ServiceId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_ServiceRequest_Services");
            });

            modelBuilder.Entity<Сlient>(entity =>
            {
                entity.Property(a => a.Id).HasColumnName("id");
                entity.Property(b => b.Name).HasColumnName("name");
                entity.HasMany(c => c.Requests).WithOne(d => d.Сlient).OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
