using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GroupClue.Data;

namespace data2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160920192039_addImagesToEvents")]
    partial class addImagesToEvents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("data.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 2147483647);

                    b.Property<DateTime>("EndTime");

                    b.Property<long?>("GroupId");

                    b.Property<string>("Location");

                    b.Property<long?>("MainImageId");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("State");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("GroupId");

                    b.HasIndex("MainImageId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("data.Models.EventImage", b =>
                {
                    b.Property<long>("EventId");

                    b.Property<long>("ImageId");

                    b.HasKey("EventId", "ImageId");

                    b.HasIndex("EventId");

                    b.ToTable("EventImage");
                });

            modelBuilder.Entity("data.Models.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("data.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("GroupClue.Data.Models.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 2147483647);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<int>("State");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GroupClue.Data.Models.GroupTag", b =>
                {
                    b.Property<long>("TagId");

                    b.Property<long>("GroupId");

                    b.HasKey("TagId", "GroupId");

                    b.HasIndex("TagId");

                    b.ToTable("GroupTag");
                });

            modelBuilder.Entity("GroupClue.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("data.Models.Event", b =>
                {
                    b.HasOne("GroupClue.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupClue.Data.Models.Group", "Group")
                        .WithMany("Events")
                        .HasForeignKey("GroupId");

                    b.HasOne("data.Models.Image", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId");

                    b.HasOne("GroupClue.Models.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("data.Models.EventImage", b =>
                {
                    b.HasOne("data.Models.Event")
                        .WithMany("EventImages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("data.Models.Image", b =>
                {
                    b.HasOne("GroupClue.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupClue.Models.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("data.Models.Tag", b =>
                {
                    b.HasOne("GroupClue.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupClue.Models.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("GroupClue.Data.Models.Group", b =>
                {
                    b.HasOne("GroupClue.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupClue.Models.ApplicationUser", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");
                });

            modelBuilder.Entity("GroupClue.Data.Models.GroupTag", b =>
                {
                    b.HasOne("data.Models.Tag")
                        .WithMany("GroupTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GroupClue.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GroupClue.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupClue.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
