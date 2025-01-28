using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("User_Role");

            builder
                .HasKey(ur => ur.Id)
                .HasName("PK_UserRole_PrimaryKey");

            builder
                .Property(ur => ur.Id)
                .ValueGeneratedOnAdd();

            // Relation : 1 UserRole a 1 User et 1 User a plusieurs UserRole.
            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .HasConstraintName("FK_UserRoles_User")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 UserRole a 1 Role et 1 Role a plusieurs UserRole. 
            builder
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .HasConstraintName("FK_UserRoles_Role")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/** NOTES*
 *
 * Table intermédiaire permettant de lier les utilisateurs aux rôles. Un User peut avoir plusieurs rôles, d'où l'intéret de cette table intermédiaire.
 * 
 * Relations avec User et Role : un user peut avoir plusieurs rôles, un rôle peut être attribué à plusieurs utilisateurs. 
*/