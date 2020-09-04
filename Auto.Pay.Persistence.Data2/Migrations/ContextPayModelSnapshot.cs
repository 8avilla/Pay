﻿// <auto-generated />
using System;
using Auto.Pay.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auto.Pay.Persistence.Data2.Migrations
{
    [DbContext(typeof(ContextPay))]
    partial class ContextPayModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Auto.Pay.Persistence.Entities.OrderEP", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("AmountPaid")
                        .HasColumnName("AmountPaid")
                        .HasColumnType("bigint");

                    b.Property<string>("ClientId")
                        .HasColumnName("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnName("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionPaymentStatus")
                        .HasColumnName("DescriptionPaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnName("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FailUrl")
                        .HasColumnName("FailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .HasColumnName("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JsonParams")
                        .HasColumnName("JsonParams")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnName("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerchantLogin")
                        .HasColumnName("MerchantLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderCredibancoId")
                        .IsRequired()
                        .HasColumnName("OrderCredibancoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrdersObject")
                        .IsRequired()
                        .HasColumnName("OrdersObject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrdersStatusObject")
                        .HasColumnName("OrdersStatusObject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageView")
                        .HasColumnName("PageView")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentFromUrlCredibanco")
                        .HasColumnName("PaymentFromUrlCredibanco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PaymentReferenceId")
                        .HasColumnName("PaymentReferenceId")
                        .HasColumnType("bigint");

                    b.Property<int>("PaymentStatus")
                        .HasColumnName("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<string>("ReturnUrl")
                        .HasColumnName("ReturnUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SessionTimeoutSecs")
                        .HasColumnName("SessionTimeoutSecs")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PaymentReferenceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Auto.Pay.Persistence.Entities.PaymentReferenceEP", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnName("Amount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentReferenceCode")
                        .IsRequired()
                        .HasColumnName("PaymentReferenceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentReferenceObject")
                        .IsRequired()
                        .HasColumnName("PaymentReferenceObject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentReference");
                });

            modelBuilder.Entity("Auto.Pay.Persistence.Entities.OrderEP", b =>
                {
                    b.HasOne("Auto.Pay.Persistence.Entities.PaymentReferenceEP", "PaymentReference")
                        .WithMany()
                        .HasForeignKey("PaymentReferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}