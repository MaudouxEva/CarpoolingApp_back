using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder
                .HasKey(r => r.Id)
                .HasName("PK_Role_PrimaryKey");

            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");
            // index unique sur le nom 
            builder
                .HasIndex(r => r.Name)
                .IsUnique();

            // Relation : 1 Role peut appartenir à plusieurs User (via la table intermédiaire UserRole)
            builder
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .HasConstraintName("FK_UserRole_Role")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/** NOTES
 *
 * Table de référence pour les rôles des utilisateurs
 */

