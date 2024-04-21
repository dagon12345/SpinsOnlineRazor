﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpinsOnlineRazor.Data;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    [DbContext(typeof(SpinsContext))]
    [Migration("20240421074731_AddedProvince")]
    partial class AddedProvince
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.Property<int>("BeneficiaryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtName")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("HealthRemarks")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("HealthStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("IdentificationDateIssued")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdentificationTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecificAddress")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("BeneficiaryID");

                    b.HasIndex("HealthStatusID");

                    b.HasIndex("IdentificationTypeID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("RegionID");

                    b.ToTable("Beneficiary", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", b =>
                {
                    b.Property<int>("HealthStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("HealthStatusID");

                    b.ToTable("HealthStatus", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.IdentificationType", b =>
                {
                    b.Property<int>("IdentificationTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("IdentificationTypeID");

                    b.ToTable("IdentificationType", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProvinceID");

                    b.ToTable("Province", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("RegionID");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", "HealthStatus")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("HealthStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.IdentificationType", "IdentificationType")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("IdentificationTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Province", "Province")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Region", "Region")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthStatus");

                    b.Navigation("IdentificationType");

                    b.Navigation("Province");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.IdentificationType", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Province", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Region", b =>
                {
                    b.Navigation("Beneficiaries");
                });
#pragma warning restore 612, 618
        }
    }
}
