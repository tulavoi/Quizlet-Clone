﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCards.Areas.Identity.Data;

#nullable disable

namespace SmartCards.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ffd6f260-8df9-4ed4-9944-9be11aa04876",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "7d3669c8-4383-48dc-a284-94a08e624b5e",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("SmartCards.Areas.Identity.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AvatarFileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SmartCards.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SmartCards.Models.CourseFolder", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FolderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId", "FolderId");

                    b.HasIndex("FolderId");

                    b.ToTable("CourseFolder");
                });

            modelBuilder.Entity("SmartCards.Models.CoursePermission", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("EditPermissionId")
                        .HasColumnType("int");

                    b.Property<int>("ViewPermissionId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "EditPermissionId", "ViewPermissionId");

                    b.HasIndex("EditPermissionId");

                    b.HasIndex("ViewPermissionId");

                    b.ToTable("CoursePermissions");
                });

            modelBuilder.Entity("SmartCards.Models.Flashcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Definition_LangId")
                        .HasColumnType("int");

                    b.Property<string>("ImageFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMark")
                        .HasColumnType("bit");

                    b.Property<int>("Term_LangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Definition_LangId");

                    b.HasIndex("Term_LangId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("SmartCards.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("SmartCards.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "en",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(722),
                            Name = "English",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(722)
                        },
                        new
                        {
                            Id = 2,
                            Code = "fr",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(725),
                            Name = "French",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(725)
                        },
                        new
                        {
                            Id = 3,
                            Code = "de",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(727),
                            Name = "German",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(728)
                        },
                        new
                        {
                            Id = 4,
                            Code = "es",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(729),
                            Name = "Spanish",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(730)
                        },
                        new
                        {
                            Id = 5,
                            Code = "it",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(731),
                            Name = "Italian",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(732)
                        },
                        new
                        {
                            Id = 6,
                            Code = "pt",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(733),
                            Name = "Portuguese",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(734)
                        },
                        new
                        {
                            Id = 7,
                            Code = "zh",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(735),
                            Name = "Chinese",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(736)
                        },
                        new
                        {
                            Id = 8,
                            Code = "ja",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(737),
                            Name = "Japanese",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(738)
                        },
                        new
                        {
                            Id = 9,
                            Code = "ru",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(739),
                            Name = "Russian",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(740)
                        },
                        new
                        {
                            Id = 10,
                            Code = "ar",
                            CreatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(741),
                            Name = "Arabic",
                            UpdatedAt = new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(742)
                        });
                });

            modelBuilder.Entity("SmartCards.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEdit")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Chỉ những người có mật khẩu mới có thể sử dụng học phần này",
                            IsEdit = false,
                            Name = "Người có mật khẩu"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Chỉ tôi mới có thể sử dụng học phần này",
                            IsEdit = false,
                            Name = "Chỉ tôi"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Mọi người đều có thể sử dụng học phần này",
                            IsEdit = false,
                            Name = "Mọi người"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Chỉ những người có mật khẩu mới có thể chỉnh sửa học phần này",
                            IsEdit = true,
                            Name = "Người có mật khẩu"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Chỉ tôi mới có thể chỉnh sửa học phần này",
                            IsEdit = true,
                            Name = "Chỉ tôi"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartCards.Models.Course", b =>
                {
                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", "User")
                        .WithMany("Courses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartCards.Models.CourseFolder", b =>
                {
                    b.HasOne("SmartCards.Models.Course", "Course")
                        .WithMany("CourseFolders")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Models.Folder", "Folder")
                        .WithMany("FolderDecks")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("SmartCards.Models.CoursePermission", b =>
                {
                    b.HasOne("SmartCards.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Models.Permission", "EditPermission")
                        .WithMany()
                        .HasForeignKey("EditPermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SmartCards.Models.Permission", "ViewPermission")
                        .WithMany()
                        .HasForeignKey("ViewPermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("EditPermission");

                    b.Navigation("ViewPermission");
                });

            modelBuilder.Entity("SmartCards.Models.Flashcard", b =>
                {
                    b.HasOne("SmartCards.Models.Course", "Course")
                        .WithMany("Flashcards")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Models.Language", "Definition_Lang")
                        .WithMany()
                        .HasForeignKey("Definition_LangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Models.Language", "Term_Lang")
                        .WithMany()
                        .HasForeignKey("Term_LangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Definition_Lang");

                    b.Navigation("Term_Lang");
                });

            modelBuilder.Entity("SmartCards.Models.Folder", b =>
                {
                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartCards.Areas.Identity.Data.AppUser", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Folders");
                });

            modelBuilder.Entity("SmartCards.Models.Course", b =>
                {
                    b.Navigation("CourseFolders");

                    b.Navigation("Flashcards");
                });

            modelBuilder.Entity("SmartCards.Models.Folder", b =>
                {
                    b.Navigation("FolderDecks");
                });
#pragma warning restore 612, 618
        }
    }
}
