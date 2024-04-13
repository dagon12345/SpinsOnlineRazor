﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpinsOnlineRazor.Data;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    [DbContext(typeof(SpinsContext))]
    partial class SpinsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Assessment", b =>
                {
                    b.Property<int>("AssessmentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AssessmentID");

                    b.ToTable("Assessment");
                });

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

                    b.HasKey("MasterlistID");

                    b.HasIndex("BarangayID");

                    b.HasIndex("BeneficiaryID");

                    b.HasIndex("MunicipalityID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("RegionID");

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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ValidationForm", b =>
                {
                    b.Property<int>("ValidationformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssessmentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeneficiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReferenceCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpinsBatch")
                        .HasColumnType("INTEGER");

                    b.HasKey("ValidationformID");

                    b.HasIndex("AssessmentID");

                    b.HasIndex("BeneficiaryID");

                    b.ToTable("ValidationForm");
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

                    b.Navigation("Barangay");

                    b.Navigation("Beneficiary");

                    b.Navigation("Municipality");

                    b.Navigation("Province");

                    b.Navigation("Region");
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ValidationForm", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Assessment", "Assessment")
                        .WithMany("ValidationForms")
                        .HasForeignKey("AssessmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", "Beneficiary")
                        .WithMany("ValidationForm")
                        .HasForeignKey("BeneficiaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");

                    b.Navigation("Beneficiary");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Assessment", b =>
                {
                    b.Navigation("ValidationForms");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Barangay", b =>
                {
                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.Navigation("Masterlists");

                    b.Navigation("ValidationForm");
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
#pragma warning restore 612, 618
        }
    }
}
