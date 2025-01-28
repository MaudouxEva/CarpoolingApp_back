using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User> 
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder
            .HasKey(u => u.Id)
            .HasName("PK_User_PrimaryKey"); // contrainte clé primaire
        builder
            .Property(u => u.Id)
            .ValueGeneratedOnAdd(); // auto-incrémente

        builder
            .Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar");
        
        builder
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar");

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar");
        builder
            .HasIndex(u => u.Email)
            .IsUnique();
        
        builder.Property(u => u.PasswordHash) 
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("text");

        builder
            .Property(u => u.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
        
        // Relation : 1 User appartient à 1 Institution
        builder
            .HasOne(u => u.Institution)
            .WithMany(i => i.Users)
            .HasForeignKey(u => u.InstitutionId)
            .HasConstraintName("FK_User_Institution")
            .OnDelete(DeleteBehavior.Restrict);

        // Relation : 1 User peut avoir plusieurs Request
        builder
            .HasMany(u => u.Requests)
            .WithOne(r => r.User) 
            .HasForeignKey(r => r.UserId)
            .HasConstraintName("FK_Requests_User")
            .OnDelete(DeleteBehavior.Restrict);
        
        // Relation : 1 User peut avoir plusieurs préférences de filtrage d'alertes
        builder
            .HasMany(u => u.UserLocationPreferences)
            .WithOne(ulp => ulp.User)
            .HasForeignKey(ulp => ulp.UserId)
            .HasConstraintName("FK_UserLocationPreferences_User")
            .OnDelete(DeleteBehavior.Restrict);

        // Relation : 1 User peut avoir plusieurs rôles (être gestionnaire d'un établissement et en même temps vouloir faire du covoiturage (= user))
        builder
            .HasMany(u => u.UserRoles) 
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .HasConstraintName("FK_UserRoles_User")
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    /** NOTES
     *
     * La table User contient les informations des utilisateurs (tous confondus) de l'application.
     * 
     * OnDelete : je ne fais pas de suppression d'un utilisateur : il est actif ou inactif.
     * Le comportement OnDelete aura peu d'impact car il ne sera quasi jamais déclenché.
     * J'ai tout de même choisi de mettre le comportement sur Resctrict : on ne peut pas supprimer un utilisateur s'il a des dépendances.
     * 
     **/
}