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
    [Migration("20240414005320_SexFK")]
    partial class SexFK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Barangay", b =>
                {
                    b.Property<int>("BarangayID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("BarangayID");

                    b.HasIndex("MunicipalityID");

                    b.ToTable("Barangay", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Beneficiary", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Masterlist", b =>
                {
                    b.Property<int>("MasterlistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarangayID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeneficiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SexID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MasterlistID");

                    b.HasIndex("BarangayID");

                    b.HasIndex("BeneficiaryID");

                    b.HasIndex("MunicipalityID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("RegionID");

                    b.HasIndex("SexID");

                    b.ToTable("Masterlist", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Municipality", b =>
                {
                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MunicipalityID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("Municipality", (string)null);
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

                    b.HasIndex("RegionID");

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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Sex", b =>
                {
                    b.Property<int>("SexID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("SexID");

                    b.ToTable("Sex", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Barangay", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Municipality", "Municipality")
                        .WithMany("Barangays")
                        .HasForeignKey("MunicipalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Masterlist", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Barangay", "Barangay")
                        .WithMany("Masterlists")
                        .HasForeignKey("BarangayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", "Beneficiary")
                        .WithMany("Masterlists")
                        .HasForeignKey("BeneficiaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Municipality", "Municipality")
                        .WithMany("Masterlists")
                        .HasForeignKey("MunicipalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Province", "Province")
                        .WithMany("Masterlists")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Region", "Region")
                        .WithMany("Masterlists")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Sex", "Sex")
                        .WithMany("Masterlists")
                        .HasForeignKey("SexID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barangay");

                    b.Navigation("Beneficiary");

                    b.Navigation("Municipality");

                    b.Navigation("Province");

                    b.Navigation("Region");

                    b.Navigation("Sex");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Municipality", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Province", "Province")
                        .WithMany("Municipalities")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Province", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Region", "Region")
                        .WithMany("Provinces")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Barangay", b =>
                {
                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Municipality", b =>
                {
                    b.Navigation("Barangays");

                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Province", b =>
                {
                    b.Navigation("Masterlists");

                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Region", b =>
                {
                    b.Navigation("Masterlists");

                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Sex", b =>
                {
                    b.Navigation("Masterlists");
                });
#pragma warning restore 612, 618
        }
    }
}
