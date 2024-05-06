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

                    b.ToTable("Barangay", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.Property<int>("BeneficiaryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BarangayID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeceasedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EnteredBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExclusionBatch")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExclusionDate")
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

                    b.Property<DateTime?>("InclusionDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("MaritalstatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SexID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecificAddress")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusRemarks")
                        .HasColumnType("TEXT");

                    b.HasKey("BeneficiaryID");

                    b.HasIndex("BarangayID");

                    b.HasIndex("HealthStatusID");

                    b.HasIndex("IdentificationTypeID");

                    b.HasIndex("MaritalstatusID");

                    b.HasIndex("MunicipalityID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("RegionID");

                    b.HasIndex("SexID");

                    b.HasIndex("StatusID");

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

                    b.Property<int?>("AssessmentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeneficiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GisPdfUrl")
                        .HasColumnType("TEXT");

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

                    b.HasIndex("BeneficiaryID")
                        .IsUnique();

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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BeneficiaryID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeEntry")
                        .HasColumnType("TEXT");

                    b.Property<int>("LogType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("User")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiaryID");

                    b.ToTable("Log", (string)null);
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Maritalstatus", b =>
                {
                    b.Property<int>("MaritalstatusID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("MaritalstatusID");

                    b.ToTable("Maritalstatus", (string)null);
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Barangay", "Barangay")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("BarangayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Maritalstatus", "Maritalstatus")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("MaritalstatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Municipality", "Municipality")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("MunicipalityID")
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

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Sex", "Sex")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("SexID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Status", "Status")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barangay");

                    b.Navigation("HealthStatus");

                    b.Navigation("IdentificationType");

                    b.Navigation("Maritalstatus");

                    b.Navigation("Municipality");

                    b.Navigation("Province");

                    b.Navigation("Region");

                    b.Navigation("Sex");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Validationform", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Assessment", "Assessment")
                        .WithMany("Validationforms")
                        .HasForeignKey("AssessmentID");

                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", "Beneficiary")
                        .WithOne("Validationform")
                        .HasForeignKey("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Validationform", "BeneficiaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");

                    b.Navigation("Beneficiary");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Log", b =>
                {
                    b.HasOne("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", "Beneficiary")
                        .WithMany("Logs")
                        .HasForeignKey("BeneficiaryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beneficiary");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Barangay", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Beneficiary", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("Validationform");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.ComplexModels.Assessment", b =>
                {
                    b.Navigation("Validationforms");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.HealthStatus", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.IdentificationType", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Maritalstatus", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Municipality", b =>
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

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Sex", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("SpinsOnlineRazor.Models.RedesignModels.Status", b =>
                {
                    b.Navigation("Beneficiaries");
                });
#pragma warning restore 612, 618
        }
    }
}
