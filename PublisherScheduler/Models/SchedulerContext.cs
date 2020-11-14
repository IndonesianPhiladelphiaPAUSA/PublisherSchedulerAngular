using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PublisherScheduler.Models
{
    public partial class SchedulerContext : DbContext
    {
        public SchedulerContext()
        {
        }

        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Capacities> Capacities { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<PersonAvails> PersonAvails { get; set; }
        public virtual DbSet<PersonCapacities> PersonCapacities { get; set; }
        public virtual DbSet<PersonTaskTypes> PersonTaskTypes { get; set; }
        public virtual DbSet<PersonTrainings> PersonTrainings { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<ProjectPersons> ProjectPersons { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Slots> Slots { get; set; }
        public virtual DbSet<TaskTypeCapacities> TaskTypeCapacities { get; set; }
        public virtual DbSet<TaskTypes> TaskTypes { get; set; }
        public virtual DbSet<Trainings> Trainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=ConnectionStrings:SchedulerConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Assignments_Locations");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Assignments_Persons");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("FK_Assignments_Slots");
            });

            modelBuilder.Entity<Capacities>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PersonAvails>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAvails)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonAvails_Person");
            });

            modelBuilder.Entity<PersonCapacities>(entity =>
            {
                entity.HasOne(d => d.Capacity)
                    .WithMany(p => p.PersonCapacities)
                    .HasForeignKey(d => d.CapacityId)
                    .HasConstraintName("FK_PersonCapacities_Capacities");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonCapacities)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonCapacities_Persons");
            });

            modelBuilder.Entity<PersonTrainings>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonTrainings)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonTrainings_Persons");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.PersonTrainings)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_PersonTrainings_Trainings");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Aspnetuserid)
                    .HasColumnName("aspnetuserid")
                    .HasMaxLength(128);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProjectPersons>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ProjectPersons)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPersons_Persons");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPersons)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPersons_Projects");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Slots>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Slots_Projects");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.TaskTypeId)
                    .HasConstraintName("FK_Slots_TaskTypes");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.TrainingId)
                    .HasConstraintName("FK_Slots_Trainings");
            });

            modelBuilder.Entity<TaskTypeCapacities>(entity =>
            {
                entity.Property(e => e.CapacityId).HasColumnName("Capacity_Id");

                entity.Property(e => e.TaskTypeId).HasColumnName("TaskType_Id");

                entity.HasOne(d => d.Capacity)
                    .WithMany(p => p.TaskTypeCapacities)
                    .HasForeignKey(d => d.CapacityId)
                    .HasConstraintName("FK_TaskTypeCapacities_Capacity");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.TaskTypeCapacities)
                    .HasForeignKey(d => d.TaskTypeId)
                    .HasConstraintName("FK_TaskTypeCapacities_TaskType");
            });

            modelBuilder.Entity<TaskTypes>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Trainings>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
