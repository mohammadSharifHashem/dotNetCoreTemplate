using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Project.Entity.Models
{
    public partial class TemplateDBContext : DbContext
    {
        public TemplateDBContext()
        {
        }

        public TemplateDBContext(DbContextOptions<TemplateDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionLogs> ActionLogs { get; set; }
        public virtual DbSet<AppAccessTokens> AppAccessTokens { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<MediaFiles> MediaFiles { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<RegisteredApps> RegisteredApps { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configurationBuilder.GetConnectionString("TemplateDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<ActionLogs>(entity =>
            {
                entity.HasKey(e => e.ActionLogId);

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ActionLogs)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionLogs_Modules");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActionLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionLogs_Users");
            });

            modelBuilder.Entity<AppAccessTokens>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK_AppAccessToken");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppVersion).HasMaxLength(50);

                entity.Property(e => e.DeviceId).HasMaxLength(255);

                entity.Property(e => e.DevicePlatform).HasMaxLength(50);

                entity.Property(e => e.DeviceType).HasMaxLength(124);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IpAddress).HasMaxLength(16);

                entity.Property(e => e.PlatformVersion).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.AppAccessTokens)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAccessToken_RegisteredApps");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppAccessTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAccessToken_Users");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Iso2).HasMaxLength(16);

                entity.Property(e => e.Iso3).HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MediaFiles>(entity =>
            {
                entity.HasKey(e => e.MediaFileId);

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.MediaFiles)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_MediaFiles_Modules");
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RegisteredApps>(entity =>
            {
                entity.HasKey(e => e.AppId);

                entity.Property(e => e.AppId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.AndroidApiKey).HasMaxLength(255);

                entity.Property(e => e.AndroidLowerVersionsExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.AndroidVersionNumber).HasMaxLength(255);

                entity.Property(e => e.AppSecret)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FacebookAppId).HasMaxLength(255);

                entity.Property(e => e.FacebookAppSecret).HasMaxLength(255);

                entity.Property(e => e.GoogleApiKeyAndroid).HasMaxLength(255);

                entity.Property(e => e.GoogleApiKeyIos).HasMaxLength(255);

                entity.Property(e => e.GoogleApiKeyWeb).HasMaxLength(255);

                entity.Property(e => e.GoogleAppId).HasMaxLength(255);

                entity.Property(e => e.GoogleAppSecret).HasMaxLength(255);

                entity.Property(e => e.IosCertificateFile).HasMaxLength(255);

                entity.Property(e => e.IosCertificatePassword).HasMaxLength(255);

                entity.Property(e => e.IosLowerVersionsExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IosVersionNumber).HasMaxLength(255);
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FacebookUserId).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GoogleUserId).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(512);

                entity.Property(e => e.PasswordExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordSalt).HasMaxLength(512);

                entity.Property(e => e.TwitterUserId).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VerificationToken).HasMaxLength(512);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });
        }
    }
}
