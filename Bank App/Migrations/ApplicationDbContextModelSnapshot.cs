﻿// <auto-generated />
using System;
using MVC_MobileBankApp.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_MobileBankApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVC_MobileBankApp.Models.Admin", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerPass")
                        .HasColumnType("int");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.CEO", b =>
                {
                    b.Property<string>("CEOId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CEOId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CEOs");

                    b.HasData(
                        new
                        {
                            CEOId = "ZENITH-CEO-100",
                            Address = "10,Abayomi street",
                            Age = 22,
                            DateCreated = new DateTime(2023, 3, 6, 15, 15, 36, 579, DateTimeKind.Local).AddTicks(8236),
                            Email = "ceo93@gmail.com",
                            FirstName = "uthman",
                            Gender = 1,
                            IsActive = true,
                            LastName = "Tijani",
                            MaritalStatus = 2,
                            PhoneNumber = "+2348087054632",
                            UserId = 99
                        });
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Customer", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("AccountBalance")
                        .HasColumnType("double");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Pin")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AccountNumber");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Manager", b =>
                {
                    b.Property<string>("ManagerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("AdminRegistrationCode")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("longblob");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ManagerId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Transaction", b =>
                {
                    b.Property<string>("RefNum")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("AccountBalance")
                        .HasColumnType("double");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("longtext");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("CustomerAccountNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DateCreated")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Pin")
                        .HasColumnType("longtext");

                    b.Property<string>("RecipientAccountNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("TransactType")
                        .HasColumnType("int");

                    b.HasKey("RefNum");

                    b.HasIndex("CustomerAccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PassWord")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 99,
                            Email = "ceo93@gmail.com",
                            IsActive = true,
                            PassWord = "$2b$10$TTLiRlERCsRl3OZR6kSua..OHido.lrlrxcASUyAUD602B3zcUkSG",
                            Role = "CEO"
                        });
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Admin", b =>
                {
                    b.HasOne("MVC_MobileBankApp.Models.User", null)
                        .WithOne("Admin")
                        .HasForeignKey("MVC_MobileBankApp.Models.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.CEO", b =>
                {
                    b.HasOne("MVC_MobileBankApp.Models.User", null)
                        .WithOne("Ceo")
                        .HasForeignKey("MVC_MobileBankApp.Models.CEO", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Customer", b =>
                {
                    b.HasOne("MVC_MobileBankApp.Models.User", null)
                        .WithOne("Customer")
                        .HasForeignKey("MVC_MobileBankApp.Models.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Manager", b =>
                {
                    b.HasOne("MVC_MobileBankApp.Models.User", null)
                        .WithOne("Manager")
                        .HasForeignKey("MVC_MobileBankApp.Models.Manager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.Transaction", b =>
                {
                    b.HasOne("MVC_MobileBankApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerAccountNumber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MVC_MobileBankApp.Models.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Ceo");

                    b.Navigation("Customer");

                    b.Navigation("Manager");
                });
#pragma warning restore 612, 618
        }
    }
}
