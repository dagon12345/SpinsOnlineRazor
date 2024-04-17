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

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecificAddress")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("BeneficiaryID");

                    b.HasIndex("HealthStatusID");

                    b.ToTable("Beneficiary", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Assessment", b =>
                {
                    b.Property<int>("AssessmentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AssessmentID");

                    b.ToTable("Assessment", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Validationform", b =>
                {
                    b.Property<int>("ValidationformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssessmentID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Indigenous")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Pantawid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReferenceCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpinsBatch")
                        .HasColumnType("INTEGER");

                    b.HasKey("ValidationformID");

                    b.HasIndex("AssessmentID");

                    b.ToTable("Validationform", (string)null);
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Maritalstatus", b =>
                {
                    b.Property<int>("MaritalstatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("MaritalstatusID");

                    b.ToTable("MaritalStatus", (string)null);
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

                    b.Property<int?>("HealthStatusID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentificationTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaritalstatusID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SexID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValidationformID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MasterlistID");

                    b.HasIndex("BarangayID");

                    b.HasIndex("BeneficiaryID");

                    b.HasIndex("HealthStatusID");

                    b.HasIndex("IdentificationTypeID");

                    b.HasIndex("MaritalstatusID");

                    b.HasIndex("MunicipalityID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("RegionID");

                    b.HasIndex("SexID");

                    b.HasIndex("StatusID");

                    b.HasIndex("ValidationformID");

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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("StatusID");

                    b.ToTable("Status", (string)null);
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", "HealthStatus")
                        .WithMany()
                        .HasForeignKey("HealthStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthStatus");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Validationform", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Assessment", "Assessment")
                        .WithMany("Validationforms")
                        .HasForeignKey("AssessmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");
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

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", null)
                        .WithMany("Masterlists")
                        .HasForeignKey("HealthStatusID");

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.IdentificationType", "IdentificationType")
                        .WithMany("Masterlists")
                        .HasForeignKey("IdentificationTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Maritalstatus", "Maritalstatus")
                        .WithMany("Masterlists")
                        .HasForeignKey("MaritalstatusID")
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

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Status", "Status")
                        .WithMany("Masterlists")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Validationform", "Validationform")
                        .WithMany("Masterlists")
                        .HasForeignKey("ValidationformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barangay");

                    b.Navigation("Beneficiary");

                    b.Navigation("IdentificationType");

                    b.Navigation("Maritalstatus");

                    b.Navigation("Municipality");

                    b.Navigation("Province");

                    b.Navigation("Region");

                    b.Navigation("Sex");

                    b.Navigation("Status");

                    b.Navigation("Validationform");
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Assessment", b =>
                {
                    b.Navigation("Validationforms");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Validationform", b =>
                {
                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", b =>
                {
                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.IdentificationType", b =>
                {
                    b.Navigation("Masterlists");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Maritalstatus", b =>
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Status", b =>
                {
                    b.Navigation("Masterlists");
                });
#pragma warning restore 612, 618
        }
    }
}
