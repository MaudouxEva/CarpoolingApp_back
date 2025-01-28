using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.ToTable("Institution");

            builder
                .HasKey(i => i.Id)
                .HasName("PK_Institution_PrimaryKey");
            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar");

            builder
                .Property(i => i.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
            
            // Relation 1 Insitution est située dans 1 Location
            builder
                .HasOne(i => i.Location)
                .WithMany(l => l.Institutions)
                .HasForeignKey(i => i.LocationId)
                .HasConstraintName("FK_Institution_Location")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation 1 Insitution peut contenir plusieurs Users
            builder
                .HasMany(i => i.Users)
                .WithOne(u => u.Institution)
                .HasForeignKey(u => u.InstitutionId)
                .HasConstraintName("FK_User_Institution")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/** NOTES
 *
 * La table Institution contient les informations des établissements inscrits sur l'application de covoiturage.
 * 
 * La relation vers Location est déjà configurée dans LocationConfiguration mais je redondate dans un souci de clarté et de compréhension.
 */
