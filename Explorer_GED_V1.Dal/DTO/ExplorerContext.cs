using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Explorer_GED_V1.Dal.DTO
{
    public partial class ExplorerContext : DbContext
    {
        public ExplorerContext()
        {
        }

        public ExplorerContext(DbContextOptions<ExplorerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Commune> Communes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Father> Fathers { get; set; }
        public virtual DbSet<Mother> Mothers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("Agent");

                entity.Property(e => e.AgentId).ValueGeneratedNever();

                entity.Property(e => e.AgentCellphone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AgentCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.AgentEmail).HasMaxLength(50);

                entity.Property(e => e.AgentName).HasMaxLength(50);

                entity.Property(e => e.AgentPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AgentPostName).HasMaxLength(50);

                entity.Property(e => e.AgentSurname).HasMaxLength(50);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_Agent_UserType");
            });

            modelBuilder.Entity<Commune>(entity =>
            {
                entity.ToTable("Commune");

                entity.Property(e => e.CommuneId).ValueGeneratedNever();

                entity.Property(e => e.CommuneDescription).HasMaxLength(50);

                entity.Property(e => e.CommuneName).HasMaxLength(50);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.Property(e => e.DocumentDescription).HasMaxLength(50);

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DocumentType).HasMaxLength(50);
            });

            modelBuilder.Entity<Father>(entity =>
            {
                entity.ToTable("Father");

                entity.Property(e => e.FatherId).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Mother>(entity =>
            {
                entity.ToTable("Mother");

                entity.Property(e => e.MotherId).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.CardExpiryDate).HasMaxLength(50);

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.CellulairePayment).HasMaxLength(50);

                entity.Property(e => e.Cvv)
                    .HasMaxLength(50)
                    .HasColumnName("CVV");

                entity.Property(e => e.NameOnCard).HasMaxLength(50);

                entity.Property(e => e.PaymentApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentPrintingDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentReference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo).HasMaxLength(50);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Agent");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Document");

                entity.HasOne(d => d.Father)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.FatherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Father");

                entity.HasOne(d => d.Mother)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MotherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Mother");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.ProvinceId).ValueGeneratedNever();

                entity.Property(e => e.ProvinceDescription).HasMaxLength(50);

                entity.Property(e => e.ProvinceName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Cellphone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Commune).HasMaxLength(50);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.Quartier).HasMaxLength(50);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .HasColumnName("streetName");

                entity.Property(e => e.StreetNumber).HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Town).HasMaxLength(50);

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_User_Agent1");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserTypeId).ValueGeneratedNever();

                entity.Property(e => e.UserType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("UserType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
