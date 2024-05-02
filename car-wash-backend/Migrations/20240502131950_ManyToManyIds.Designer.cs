﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using car_wash_backend.Models;

#nullable disable

namespace car_wash_backend.Migrations
{
    [DbContext(typeof(CarWashContext))]
    [Migration("20240502131950_ManyToManyIds")]
    partial class ManyToManyIds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("car_wash_backend.Models.Box", b =>
                {
                    b.Property<long>("BoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("box_ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("BoxId"));

                    b.HasKey("BoxId")
                        .HasName("Box_pkey");

                    b.ToTable("Box", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.BoxesInCarwash", b =>
                {
                    b.Property<long>("BoxId")
                        .HasColumnType("bigint")
                        .HasColumnName("box_ID");

                    b.Property<Guid?>("BoxesInCarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("boxesInCarwash_ID");

                    b.Property<Guid>("CarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("carwash_ID");

                    b.HasIndex("CarwashId");

                    b.HasIndex(new[] { "BoxId" }, "pk_box_ID")
                        .IsUnique();

                    b.ToTable("BoxesInCarwash", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Carwash", b =>
                {
                    b.Property<Guid>("CarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("carwash_ID");

                    b.Property<int>("BoxAmount")
                        .HasColumnType("integer")
                        .HasColumnName("boxAmount");

                    b.Property<string>("CarwashStreet")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("carwashStreet");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("contactInfo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("CarwashId")
                        .HasName("Carwashes_pkey");

                    b.ToTable("Carwash", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Day", b =>
                {
                    b.Property<Guid>("DayId")
                        .HasColumnType("uuid")
                        .HasColumnName("day_ID");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("endTime");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("startTime");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("type_ID");

                    b.HasKey("DayId")
                        .HasName("Day_pkey");

                    b.HasIndex("TypeId");

                    b.ToTable("Day", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.DayType", b =>
                {
                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("type_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("TypeId")
                        .HasName("DayType_pkey");

                    b.ToTable("DayType", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("employee_ID");

                    b.Property<Guid>("CarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("carwash_ID");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_ID");

                    b.HasKey("EmployeeId")
                        .HasName("Employees_pkey");

                    b.HasIndex("CarwashId");

                    b.HasIndex("UserId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_ID");

                    b.Property<long>("BoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("box_ID")
                        .HasDefaultValueSql("nextval('\"Orders_box_ID_seq\"'::regclass)");

                    b.Property<Guid>("CarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("carwash_ID");

                    b.Property<DateOnly>("DateTime")
                        .HasColumnType("date")
                        .HasColumnName("date_time");

                    b.Property<string>("LicencePlate")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("licencePlate");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid")
                        .HasColumnName("status_ID");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_ID");

                    b.HasKey("OrderId")
                        .HasName("Orders_pkey");

                    b.HasIndex("BoxId");

                    b.HasIndex("CarwashId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.OrderStatus", b =>
                {
                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid")
                        .HasColumnName("status_ID");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("statusName");

                    b.HasKey("StatusId")
                        .HasName("OrderStatus_pkey");

                    b.ToTable("OrderStatus", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Person", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid")
                        .HasColumnName("person_ID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("FathersName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("fathersName");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("lastName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("phoneNumber");

                    b.HasKey("PersonId")
                        .HasName("Person_pkey");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_ID");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("roleName");

                    b.HasKey("RoleId")
                        .HasName("Roles_pkey");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Schedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uuid")
                        .HasColumnName("schedule_ID");

                    b.Property<Guid>("CarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("carwash_ID");

                    b.Property<Guid>("DayId")
                        .HasColumnType("uuid")
                        .HasColumnName("day_ID");

                    b.HasKey("ScheduleId")
                        .HasName("Schedule_pkey");

                    b.HasIndex("DayId");

                    b.ToTable("Schedule", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.Service", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid")
                        .HasColumnName("service_ID");

                    b.Property<Guid>("CarwashId")
                        .HasColumnType("uuid")
                        .HasColumnName("carwash_ID");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<long>("Price")
                        .HasColumnType("bigint")
                        .HasColumnName("price");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid")
                        .HasColumnName("status_ID");

                    b.HasKey("ServiceId")
                        .HasName("Service_pkey");

                    b.HasIndex("CarwashId");

                    b.HasIndex("StatusId");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.ServiceStatus", b =>
                {
                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid")
                        .HasColumnName("status_ID");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("statusName");

                    b.HasKey("StatusId")
                        .HasName("ServiceStatus_pkey");

                    b.ToTable("ServiceStatus", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.ServicesInOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_ID");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid")
                        .HasColumnName("service_ID");

                    b.Property<Guid?>("ServicesInOrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("servicesInOrder_ID");

                    b.HasIndex("OrderId");

                    b.HasIndex(new[] { "ServiceId" }, "pk_service_ID")
                        .IsUnique();

                    b.ToTable("ServicesInOrder", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_ID");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid")
                        .HasColumnName("person_ID");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_ID");

                    b.HasKey("UserId")
                        .HasName("Users_pkey");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("car_wash_backend.Models.BoxesInCarwash", b =>
                {
                    b.HasOne("car_wash_backend.Models.Box", "Box")
                        .WithOne()
                        .HasForeignKey("car_wash_backend.Models.BoxesInCarwash", "BoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_box_ID");

                    b.HasOne("car_wash_backend.Models.Carwash", "Carwash")
                        .WithMany()
                        .HasForeignKey("CarwashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_carwash_ID");

                    b.Navigation("Box");

                    b.Navigation("Carwash");
                });

            modelBuilder.Entity("car_wash_backend.Models.Day", b =>
                {
                    b.HasOne("car_wash_backend.Models.DayType", "Type")
                        .WithMany("Days")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_type_ID");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("car_wash_backend.Models.Employee", b =>
                {
                    b.HasOne("car_wash_backend.Models.Carwash", "Carwash")
                        .WithMany("Employees")
                        .HasForeignKey("CarwashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_carwash_ID");

                    b.HasOne("car_wash_backend.Models.User", "User")
                        .WithMany("Employees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_ID");

                    b.Navigation("Carwash");

                    b.Navigation("User");
                });

            modelBuilder.Entity("car_wash_backend.Models.Order", b =>
                {
                    b.HasOne("car_wash_backend.Models.Box", "Box")
                        .WithMany("Orders")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_box_ID");

                    b.HasOne("car_wash_backend.Models.Carwash", "Carwash")
                        .WithMany("Orders")
                        .HasForeignKey("CarwashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_carwash_ID");

                    b.HasOne("car_wash_backend.Models.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_status_ID");

                    b.HasOne("car_wash_backend.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_ID");

                    b.Navigation("Box");

                    b.Navigation("Carwash");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("car_wash_backend.Models.Schedule", b =>
                {
                    b.HasOne("car_wash_backend.Models.Day", "Day")
                        .WithMany("Schedules")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_day_ID");

                    b.Navigation("Day");
                });

            modelBuilder.Entity("car_wash_backend.Models.Service", b =>
                {
                    b.HasOne("car_wash_backend.Models.Carwash", "Carwash")
                        .WithMany("Services")
                        .HasForeignKey("CarwashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_carwash_ID");

                    b.HasOne("car_wash_backend.Models.ServiceStatus", "Status")
                        .WithMany("Services")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_status_ID");

                    b.Navigation("Carwash");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("car_wash_backend.Models.ServicesInOrder", b =>
                {
                    b.HasOne("car_wash_backend.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_ID");

                    b.HasOne("car_wash_backend.Models.Service", "Service")
                        .WithOne()
                        .HasForeignKey("car_wash_backend.Models.ServicesInOrder", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_service_ID");

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("car_wash_backend.Models.User", b =>
                {
                    b.HasOne("car_wash_backend.Models.Person", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_person_ID");

                    b.HasOne("car_wash_backend.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_ID");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("car_wash_backend.Models.Box", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("car_wash_backend.Models.Carwash", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Orders");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("car_wash_backend.Models.Day", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("car_wash_backend.Models.DayType", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("car_wash_backend.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("car_wash_backend.Models.Person", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("car_wash_backend.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("car_wash_backend.Models.ServiceStatus", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("car_wash_backend.Models.User", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
