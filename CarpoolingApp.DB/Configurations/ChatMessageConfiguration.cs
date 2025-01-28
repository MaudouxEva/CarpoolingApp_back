using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpoolingApp.DB.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ToTable("ChatMessage");

            builder
                .HasKey(cm => cm.Id)
                .HasName("PK_ChatMessage_PrimaryKey");
            builder
                .Property(cm => cm.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(cm => cm.Content)
                .IsRequired()
                .HasColumnType("text");

            // Relation : un message est envoyé dans une session de chat
            builder
                .HasOne(cm => cm.ChatSession)
                .WithMany(cs => cs.ChatMessages)
                .HasForeignKey(cm => cm.ChatSessionId)
                .HasConstraintName("FK_ChatMessage_ChatSession")
                .OnDelete(DeleteBehavior.Restrict);
            
            // Relation : Chaque message est envoyé par un utilisateur
            builder
                .HasOne(cm => cm.SenderUser)
                .WithMany(u => u.ChatMessagesSent)
                .HasForeignKey(cm => cm.Sender)
                .HasConstraintName("FK_ChatMessage_SenderUser")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

/**
 *
 * La table Chatmessage contient les messages envoyés dans une session de chat entre le conducteur et le demandeur de covoiturage.
 *
 * J'en ai besoin car je veux pouvoir fermer la conversation et la rouvrir, avec l'historique des anciens messages envoyés.
 * La propriété Sender fait référence à l'identifiant de l'utilisateur qui a envoyé le message. Chaque ligne de message est prise individuellement, et écrite par un utilisateur.
 * Dans l'entité ChatMessage, il y a une propriété SenderUser qui est une référence à l'utilisateur qui a envoyé le message.
*/