using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");

            builder
                .HasKey(l => l.Id)
                .HasName("PK_Location_PrimaryKey");

            builder
                .Property(l => l.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(l => l.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar");

            builder
                .Property(l => l.PostalCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar");

            // Relation : 1 Location peut être le lieu de plusieurs Institutions
            builder
                .HasMany(l => l.Institutions)
                .WithOne(i => i.Location)
                .HasForeignKey(i => i.LocationId)
                .HasConstraintName("FK_Institution_Location")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 Location peut faire l'objet de plusieurs préférences de localisation
            builder
                .HasMany(l => l.UserLocationPreferences)
                .WithOne(ulp => ulp.Location)
                .HasForeignKey(ulp => ulp.LocationId)
                .HasConstraintName("FK_UserLocationPreferences_Location")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 Location peut être le lieu de départ de plusieurs Request
            builder
                .HasMany(l => l.RequestsAsStarting)
                .WithOne(r => r.StartingLocationNav)
                .HasForeignKey(r => r.StartingLocation)
                .HasConstraintName("FK_Request_StartingLocation")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 Location peut être le lieu d'arrivée de plusieurs Request
            builder
                .HasMany(l => l.RequestsAsEnding)
                .WithOne(r => r.EndingLocationNav)
                .HasForeignKey(r => r.EndingLocation)
                .HasConstraintName("FK_Request_EndingLocation")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/** NOTES
 * 
 * La table Location est une table générique qui contient les informations de localisation globale (ville et code postal)
 * 
 * Elle est liée à plusieurs autres tables de la base de données, notamment Institution, UserLocationPreferences et Request
 */
