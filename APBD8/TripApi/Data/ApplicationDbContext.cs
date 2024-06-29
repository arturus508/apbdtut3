using Microsoft.EntityFrameworkCore;
using TripApi.Models;

namespace TripApi.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientTrip> ClientTrips { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient).HasName("PK__Client__D5927EC79826C0B3");

                entity.ToTable("Client");

                entity.Property(e => e.Email).HasMaxLength(120);
                entity.Property(e => e.FirstName).HasMaxLength(120);
                entity.Property(e => e.LastName).HasMaxLength(120);
                entity.Property(e => e.Pesel).HasMaxLength(11);
                entity.Property(e => e.Telephone).HasMaxLength(11);
            });

            modelBuilder.Entity<ClientTrip>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.IdTrip }).HasName("ClientTrip_pk");

                entity.ToTable("ClientTrip");

                entity.Property(e => e.PaymentDate).HasColumnType("date");
                entity.Property(e => e.RegisteredAt).HasColumnType("date");

                entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ClientTrips)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientTrip_Client");

                entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.ClientTrips)
                    .HasForeignKey(d => d.IdTrip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientTrip_Trip");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry).HasName("Country_pk");

                entity.ToTable("Country");

                entity.Property(e => e.Name).HasMaxLength(120);

                entity.HasMany(d => d.IdTrips).WithMany(p => p.IdCountries)
                    .UsingEntity<Dictionary<string, object>>(
                        "CountryTrip",
                        r => r.HasOne<Trip>().WithMany()
                            .HasForeignKey("IdTrip")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("CountryTrip_Trip"),
                        l => l.HasOne<Country>().WithMany()
                            .HasForeignKey("IdCountry")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("CountryTrip_Country"),
                        j =>
                        {
                            j.HasKey("IdCountry", "IdTrip").HasName("CountryTrip_pk");
                            j.ToTable("CountryTrip");
                        });
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.IdTrip).HasName("Trip_pk");

                entity.ToTable("Trip");

                entity.Property(e => e.DateFrom).HasColumnType("date");
                entity.Property(e => e.DateTo).HasColumnType("date");
                entity.Property(e => e.Description).HasMaxLength(220);
                entity.Property(e => e.Name).HasMaxLength(120);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
