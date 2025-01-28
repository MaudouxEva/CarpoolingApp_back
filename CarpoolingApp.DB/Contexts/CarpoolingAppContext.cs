using CarpoolingApp.DB.Configurations;
using CarpoolingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingApp.DB.Contexts
{
    public class CarpoolingAppContext : DbContext
    {
        public CarpoolingAppContext(DbContextOptions<CarpoolingAppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserLocationPreference> UserLocationPreferences { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        /**
         * Je surcharge OnModelCreating pour appliquer toutes les configurations.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new UserLocationPreferenceConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new ChatSessionConfiguration());
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());

            base.OnModelCreating(modelBuilder);

            // Ajout de données pour l'initialisation du projet
            // --- Roles ---
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrator" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Member" }
            );

            // --- Locations ---
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    City = "Ciney",
                    PostalCode = "5590"
                },
                new Location
                {
                    Id = 2,
                    City = "Charleroi",
                    PostalCode = "6041"
                }
            );

            // --- Institutions ---
            modelBuilder.Entity<Institution>().HasData(
                new Institution
                {
                    Id = 1,
                    Name = "Technobel",
                    LocationId = 1, // = Ciney
                    IsActive = true
                },
                new Institution
                {
                    Id = 2,
                    Name = "Technofutur",
                    LocationId = 2, // = Charleroi
                    IsActive = true
                }
            );

            // --- Users ---
            // 1 Admin (Institution = Technobel)
            // 2 Managers (1 => Technobel, 1 => Technofutur)
            // 7 Members (majorité à Technobel)
            modelBuilder.Entity<User>().HasData(
                // Admin général
                new User
                {
                    Id = 1,
                    FirstName = "Eva",
                    LastName = "Admin",
                    Email = "eva.admin@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                // 2 Managers
                new User
                {
                    Id = 2,
                    FirstName = "Hervé",
                    LastName = "Manager",
                    Email = "herve.manager@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                new User
                {
                    Id = 3,
                    FirstName = "Gou",
                    LastName = "Manager",
                    Email = "gou.manager@technofutur.com",
                    PasswordHash = "password",
                    InstitutionId = 2,
                    IsActive = true
                },
                // 7 Members (5 à Technobel, 2 à Technofutur)
                new User
                {
                    Id = 4,
                    FirstName = "Loulou",
                    LastName = "Member",
                    Email = "loulou.member@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                new User
                {
                    Id = 5,
                    FirstName = "GG",
                    LastName = "Member",
                    Email = "gg.member@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                new User
                {
                    Id = 6,
                    FirstName = "Dydy",
                    LastName = "Member",
                    Email = "dydy.member@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                new User
                {
                    Id = 7,
                    FirstName = "Yuki",
                    LastName = "Member",
                    Email = "yuki.member@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                new User
                {
                    Id = 8,
                    FirstName = "Franchibou",
                    LastName = "Member",
                    Email = "franchibou.member@technobel.com",
                    PasswordHash = "password",
                    InstitutionId = 1,
                    IsActive = true
                },
                new User
                {
                    Id = 9,
                    FirstName = "Tic",
                    LastName = "Member",
                    Email = "tic.member@technofutur.com",
                    PasswordHash = "password",
                    InstitutionId = 2,
                    IsActive = true
                },
                new User
                {
                    Id = 10,
                    FirstName = "Tac",
                    LastName = "Member",
                    Email = "tac.member@technofutur.com",
                    PasswordHash = "password",
                    InstitutionId = 2,
                    IsActive = true
                }
            );

            // --- UserRole (liaison) ---
            // On affecte 1 => Admin, 2 => Manager, 3 => Manager, 4..10 => Member
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1 }, // user1 => admin
                new UserRole { Id = 2, UserId = 2, RoleId = 2 }, // user2 => manager
                new UserRole { Id = 3, UserId = 3, RoleId = 2 }, // user3 => manager
                new UserRole { Id = 4, UserId = 4, RoleId = 3 }, // user4 => member
                new UserRole { Id = 5, UserId = 5, RoleId = 3 }, // user5 => member
                new UserRole { Id = 6, UserId = 6, RoleId = 3 }, // user6 => member
                new UserRole { Id = 7, UserId = 7, RoleId = 3 }, // user7 => member
                new UserRole { Id = 8, UserId = 8, RoleId = 3 }, // user8 => member
                new UserRole { Id = 9, UserId = 9, RoleId = 3 }, // user9 => member
                new UserRole { Id = 10, UserId = 10, RoleId = 3 } // user10 => member
            );
        }
    }
}

/** NOTES
 *
 * Les DbSet créent un point d'accès pour interagir avec les données d'une entité en particulier.
 * Si on ne déclare pas un DbSet pour une entité dans ce contexte de db, on ne peut pas effectuer d'opérations CRUD directement sur cette entité en utilisant Entity Framework.
 * La méthode OnModelCreating est surchargée pour appliquer toutes les configurations (mapping Fluent API).
 * Je surcharge OnModelCreating pour appliquer toutes les configurationsdéfinies précédemment.
 *
 * J'ajoute un jeu de données pour l'initialisation du projet (les seeds).
 */