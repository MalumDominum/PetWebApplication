﻿// <auto-generated />
using System;
using EFDataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFDataAccessLibrary.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20210217115414_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:Collation", "English_United States.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AddressUser", b =>
                {
                    b.Property<int>("AddressesAddressId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("AddressesAddressId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("user_address");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("address_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("ApartmentNumber")
                        .HasColumnType("integer")
                        .HasColumnName("apartment_number");

                    b.Property<int>("CityId")
                        .HasColumnType("integer")
                        .HasColumnName("city_id");

                    b.Property<string>("District")
                        .HasColumnType("character varying")
                        .HasColumnName("district");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("integer")
                        .HasColumnName("house_number");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("street_name");

                    b.HasKey("AddressId");

                    b.HasIndex("CityId");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("city_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("city_name");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<string>("Region")
                        .HasColumnType("character varying")
                        .HasColumnName("region");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("comment_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AnswerOnId")
                        .HasColumnType("integer")
                        .HasColumnName("answer_on");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("content");

                    b.Property<int>("PetId")
                        .HasColumnType("integer")
                        .HasColumnName("pet_id");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("post_date");

                    b.HasKey("CommentId");

                    b.HasIndex("AnswerOnId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PetId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("country_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("country_name");

                    b.HasKey("CountryId");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("message_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("LastUpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_update_at");

                    b.Property<int>("UserReceiverId")
                        .HasColumnType("integer")
                        .HasColumnName("user_receiver_id");

                    b.Property<int>("UserSenderId")
                        .HasColumnType("integer")
                        .HasColumnName("user_sender_id");

                    b.HasKey("MessageId");

                    b.HasIndex("UserReceiverId");

                    b.HasIndex("UserSenderId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("pet_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AddressId")
                        .HasColumnType("integer")
                        .HasColumnName("address_id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("Breed")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("breed");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)")
                        .HasColumnName("description");

                    b.Property<char>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("gender");

                    b.Property<bool>("Healthy")
                        .HasColumnType("boolean")
                        .HasColumnName("healthy");

                    b.Property<DateTime?>("LastUpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_update_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<bool?>("Neutering")
                        .HasColumnType("boolean")
                        .HasColumnName("neutering");

                    b.Property<TimeSpan?>("RoughAge")
                        .IsRequired()
                        .HasColumnType("interval")
                        .HasColumnName("rough_age");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("species");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("ViewsNumber")
                        .HasColumnType("integer")
                        .HasColumnName("views_number");

                    b.HasKey("PetId");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("pets");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.PetPhoto", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("photo_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("path");

                    b.Property<int>("PetId")
                        .HasColumnType("integer")
                        .HasColumnName("pet_id");

                    b.HasKey("PhotoId")
                        .HasName("pet_photos_pkey");

                    b.HasIndex("PetId");

                    b.ToTable("pet_photos");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("status_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("title");

                    b.HasKey("StatusId");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AddressId")
                        .HasColumnType("integer")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<char>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("last_name");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_updated_at");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("phone_number");

                    b.Property<string>("PhotoPath")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("photo_path");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("PetStatus", b =>
                {
                    b.Property<int>("PetsPetId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusesStatusId")
                        .HasColumnType("integer");

                    b.HasKey("PetsPetId", "StatusesStatusId");

                    b.HasIndex("StatusesStatusId");

                    b.ToTable("pet_status");
                });

            modelBuilder.Entity("AddressUser", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressesAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Address", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .HasConstraintName("addresses_city_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.City", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("cities_country_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Comment", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Comment", "AnswerOn")
                        .WithMany("Answers")
                        .HasForeignKey("AnswerOnId")
                        .HasConstraintName("comments_answer_on_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.Pet", "Pet")
                        .WithMany("Comments")
                        .HasForeignKey("PetId")
                        .HasConstraintName("comments_pet_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerOn");

                    b.Navigation("Author");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Message", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.User", "UserReceiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("UserReceiverId")
                        .HasConstraintName("messages_user_reciver_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.User", "UserSender")
                        .WithMany("SentMessages")
                        .HasForeignKey("UserSenderId")
                        .HasConstraintName("messages_user_sender_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserReceiver");

                    b.Navigation("UserSender");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Pet", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Address", "Address")
                        .WithMany("Pets")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("pets_address_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.User", "User")
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .HasConstraintName("pets_user_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.PetPhoto", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Pet", "Pet")
                        .WithMany("PetPhotos")
                        .HasForeignKey("PetId")
                        .HasConstraintName("pet_photos_pet_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("PetStatus", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.Pet", null)
                        .WithMany()
                        .HasForeignKey("PetsPetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFDataAccessLibrary.Models.Status", null)
                        .WithMany()
                        .HasForeignKey("StatusesStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Address", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Comment", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Pet", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PetPhotos");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.User", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}