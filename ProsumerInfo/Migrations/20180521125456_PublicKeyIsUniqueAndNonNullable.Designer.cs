﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProsumerInfo.Data;
using System;

namespace ProsumerInfo.Migrations
{
    [DbContext(typeof(ProsumerInfoContext))]
    [Migration("20180521125456_PublicKeyIsUniqueAndNonNullable")]
    partial class PublicKeyIsUniqueAndNonNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProsumerInfo.Models.Prosumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PublicKey")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PublicKey")
                        .IsUnique();

                    b.ToTable("Prosumers");
                });

            modelBuilder.Entity("ProsumerInfo.Models.SmartMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GeneratedPower")
                        .HasAnnotation("PropertyAccessMode", PropertyAccessMode.Field);

                    b.Property<int>("ProsumerId");

                    b.Property<int>("UsedPower")
                        .HasAnnotation("PropertyAccessMode", PropertyAccessMode.Field);

                    b.HasKey("Id");

                    b.HasIndex("ProsumerId")
                        .IsUnique();

                    b.ToTable("SmartMeters");
                });

            modelBuilder.Entity("ProsumerInfo.Models.SmartMeter", b =>
                {
                    b.HasOne("ProsumerInfo.Models.Prosumer", "Prosumer")
                        .WithOne("SmartMeter")
                        .HasForeignKey("ProsumerInfo.Models.SmartMeter", "ProsumerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
