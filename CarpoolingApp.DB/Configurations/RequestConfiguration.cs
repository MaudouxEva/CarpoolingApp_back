using CarpoolingApp.DB.Entities;
using Covoiturage.DB.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Request");

            builder
                .HasKey(r => r.Id)
                .HasName("PK_Request_PrimaryKey");
            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(r => r.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(RequestStatus.Pending);

            // Relation : 1 requete est faite par un utilisateur et un utilisateur peut faire plusieurs requetes
            builder
                .HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.UserId)
                .HasConstraintName("FK_Requests_User")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(r => r.DesiredDateTime)
                .IsRequired();

            builder
                .Property(r => r.CreatedDate)
                .HasDefaultValueSql("NOW()");

            // Relation : 1 requête a un lieu de départ et un lieu de départ peut être le lieu de départ de plusieurs requêtes
            builder
                .HasOne(r => r.StartingLocationNav)
                .WithMany(l => l.RequestsAsStarting)
                .HasForeignKey(r => r.StartingLocation)
                .HasConstraintName("FK_Request_StartingLocation")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 requête a un lieu d'arrivée et un lieu d'arrivée peut être le lieu d'arrivée de plusieurs requêtes
            builder
                .HasOne(r => r.EndingLocationNav)
                .WithMany(l => l.RequestsAsEnding)
                .HasForeignKey(r => r.EndingLocation)
                .HasConstraintName("FK_Request_EndingLocation")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 requête, quand son statut passe à "Accepted", crée une session de chat et une session de chat est liée à une requête
            builder
                .HasMany(r => r.ChatSessions)
                .WithOne(cs => cs.Request)
                .HasForeignKey(cs => cs.RequestId)
                .HasConstraintName("FK_ChatSession_Request")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/** NOTES
 *
 * La table Request contient la demande de covoiturage d'un utilisateur.
 *
 * Le statut de la requête est stockée dans une enumération RequestStatus. Par défault, une requête à le statut "en attente".
 * Une reqûete acceptée ouvre une session de messages entre le demandeur et la personne qui a accepté.
*/