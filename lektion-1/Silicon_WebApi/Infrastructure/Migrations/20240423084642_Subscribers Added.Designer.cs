﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240423084642_Subscribers Added")]
    partial class SubscribersAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.SubscribeEntity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("AdvertisingUpdates")
                        .HasColumnType("bit");

                    b.Property<bool?>("DailyNewsletter")
                        .HasColumnType("bit");

                    b.Property<bool?>("EventUpdates")
                        .HasColumnType("bit");

                    b.Property<bool?>("Podcasts")
                        .HasColumnType("bit");

                    b.Property<bool?>("StartupsWeekly")
                        .HasColumnType("bit");

                    b.Property<bool?>("WeekinReview")
                        .HasColumnType("bit");

                    b.HasKey("Email");

                    b.ToTable("Subscribers");
                });
#pragma warning restore 612, 618
        }
    }
}
