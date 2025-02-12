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
                            Id = "1119d6cd-b873-47fa-8037-4317657b255d",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "e1129a00-4d77-4dfa-93cb-bb0f92165007",
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
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
                    b.Property<int>("FolderId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FolderId", "CourseId");

                    b.HasIndex("CourseId");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Definition_LangId")
                        .HasColumnType("int");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Term")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "en",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3889),
                            Name = "English",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3889)
                        },
                        new
                        {
                            Id = 2,
                            Code = "fr",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3891),
                            Name = "French",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3891)
                        },
                        new
                        {
                            Id = 3,
                            Code = "de",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3893),
                            Name = "German",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3893)
                        },
                        new
                        {
                            Id = 4,
                            Code = "es",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3895),
                            Name = "Spanish",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3895)
                        },
                        new
                        {
                            Id = 5,
                            Code = "it",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3897),
                            Name = "Italian",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3897)
                        },
                        new
                        {
                            Id = 6,
                            Code = "pt",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3899),
                            Name = "Portuguese",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3899)
                        },
                        new
                        {
                            Id = 7,
                            Code = "zh",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3901),
                            Name = "Chinese",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3901)
                        },
                        new
                        {
                            Id = 8,
                            Code = "ja",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3903),
                            Name = "Japanese",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3903)
                        },
                        new
                        {
                            Id = 9,
                            Code = "ru",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3905),
                            Name = "Russian",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3905)
                        },
                        new
                        {
                            Id = 10,
                            Code = "ar",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3907),
                            Name = "Arabic",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3907)
                        },
                        new
                        {
                            Id = 11,
                            Code = "vn",
                            CreatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3909),
                            Name = "Vietnamese",
                            UpdatedAt = new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3909)
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
                            Description = "Mọi người đều có thể sử dụng học phần này",
                            IsEdit = false,
                            Name = "Mọi người"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Chỉ những người có mật khẩu mới có thể sử dụng học phần này",
                            IsEdit = false,
                            Name = "Người có mật khẩu"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Chỉ tôi mới có thể sử dụng học phần này",
                            IsEdit = false,
                            Name = "Chỉ tôi"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Chỉ tôi mới có thể chỉnh sửa học phần này",
                            IsEdit = true,
                            Name = "Chỉ tôi"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Chỉ những người có mật khẩu mới có thể chỉnh sửa học phần này",
                            IsEdit = true,
                            Name = "Người có mật khẩu"
                        });
                });

            modelBuilder.Entity("SmartCards.Models.UserCourseProgress", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsShuffle")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourseProgress");
                });

            modelBuilder.Entity("SmartCards.Models.UserFlashcardProgress", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FlashcardId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLearned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStarred")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastReviewedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "FlashcardId");

                    b.HasIndex("FlashcardId");

                    b.ToTable("UserFlashcardProgress");
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
                        .WithMany("CourseFolders")
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
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartCards.Models.UserCourseProgress", b =>
                {
                    b.HasOne("SmartCards.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartCards.Models.UserFlashcardProgress", b =>
                {
                    b.HasOne("SmartCards.Models.Flashcard", "Flashcard")
                        .WithMany()
                        .HasForeignKey("FlashcardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartCards.Areas.Identity.Data.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Flashcard");

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
                    b.Navigation("CourseFolders");
                });
#pragma warning restore 612, 618
        }
    }
}
