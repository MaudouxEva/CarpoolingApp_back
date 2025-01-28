using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class UserLocationPreferenceConfiguration : IEntityTypeConfiguration<UserLocationPreference>
    {
        public void Configure(EntityTypeBuilder<UserLocationPreference> builder)
        {
            builder.ToTable("UserLocationPreference");

            builder
                .HasKey(ulp => ulp.Id)
                .HasName("PK_UserLocationPreference_PrimaryKey");

            builder
                .Property(ulp => ulp.Id)
                .ValueGeneratedOnAdd();

            // Relation : 1 User peut avoir plusieurs préférences de filtrage d'alertes
            builder
                .HasOne(ulp => ulp.User)
                .WithMany(u => u.UserLocationPreferences)
                .HasForeignKey(ulp => ulp.UserId)
                .HasConstraintName("FK_UserLocationPreferences_User")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 Location peut être la localisation de départ et/ou d'arrivée de plusieurs préférences de filtrage d'alertes
            builder
                .HasOne(ulp => ulp.Location)
                .WithMany(l => l.UserLocationPreferences)
                .HasForeignKey(ulp => ulp.LocationId)
                .HasConstraintName("FK_UserLocationPreferences_Location")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


/** NOTES
 *
 * La table UserLocationPreference contient les préférences de filtrage d'alertes des utilisateurs.
 * Un user peut choisir de filtrer les demandes de covoiturage en fonction de la localisation de départ et/ou d'arrivée.
*/