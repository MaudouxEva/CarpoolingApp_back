using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class ChatSessionConfiguration : IEntityTypeConfiguration<ChatSession>
    {
        public void Configure(EntityTypeBuilder<ChatSession> builder)
        {
            builder.ToTable("ChatSession");

            builder
                .HasKey(cs => cs.Id)
                .HasName("PK_ChatSession_PrimaryKey");
            builder
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(cs => cs.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // Relation : une session de chat est liée à une demande de covoiturage
            builder
                .HasOne(cs => cs.Request)
                .WithMany(r => r.ChatSessions)
                .HasForeignKey(cs => cs.RequestId)
                .HasConstraintName("FK_ChatSession_Request")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : une session de chat est liée à un conducteur (émetteur 1)
            builder
                .HasOne(cs => cs.Driver)
                .WithMany(u => u.ChatSessionsAsDriver)
                .HasForeignKey(cs => cs.DriverId)
                .HasConstraintName("FK_ChatSession_Driver")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : une session de chat est liée à un passager (émetteur 2)
            builder
                .HasOne(cs => cs.Applicant)
                .WithMany(u => u.ChatSessionsAsApplicant)
                .HasForeignKey(cs => cs.ApplicantId)
                .HasConstraintName("FK_ChatSession_Applicant")
                .OnDelete(DeleteBehavior.Restrict);

            // Relation : 1 session de chat contient plusieurs messages
            builder
                .HasMany(cs => cs.ChatMessages)
                .WithOne(cm => cm.ChatSession)
                .HasForeignKey(cm => cm.ChatSessionId)
                .HasConstraintName("FK_ChatMessage_ChatSession")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/**
 *
 * La table ChatSession contient les informations des sessions de chat entre un conducteur et un passager (le demandeur d'un covoiturage).
 * 
 * La session sera active tant que le covoiturage n'est pas terminé. Quand le statut du covoiturage(Request) est passé à "Completed", la session de chat est désactivée.
*/