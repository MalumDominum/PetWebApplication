using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EFDataAccessLibrary.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country_name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    photo_path = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    address_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_name = table.Column<string>(type: "character varying", nullable: false),
                    region = table.Column<string>(type: "character varying", nullable: true),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.city_id);
                    table.ForeignKey(
                        name: "cities_country_id_fkey",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_update_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_receiver_id = table.Column<int>(type: "integer", nullable: false),
                    user_sender_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.message_id);
                    table.ForeignKey(
                        name: "messages_user_reciver_id_fkey",
                        column: x => x.user_receiver_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "messages_user_sender_id_fkey",
                        column: x => x.user_sender_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street_name = table.Column<string>(type: "character varying", nullable: false),
                    house_number = table.Column<int>(type: "integer", nullable: false),
                    apartment_number = table.Column<int>(type: "integer", nullable: true),
                    district = table.Column<string>(type: "character varying", nullable: true),
                    city_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.address_id);
                    table.ForeignKey(
                        name: "addresses_city_id_fkey",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    pet_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    species = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    breed = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rough_age = table.Column<TimeSpan>(type: "interval", nullable: false),
                    neutering = table.Column<bool>(type: "boolean", nullable: true),
                    gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    healthy = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    views_number = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_update_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.pet_id);
                    table.ForeignKey(
                        name: "pets_address_id_fkey",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "pets_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_address",
                columns: table => new
                {
                    AddressesAddressId = table.Column<int>(type: "integer", nullable: false),
                    UsersUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_address", x => new { x.AddressesAddressId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_user_address_addresses_AddressesAddressId",
                        column: x => x.AddressesAddressId,
                        principalTable: "addresses",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_address_users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "character varying", nullable: false),
                    post_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    pet_id = table.Column<int>(type: "integer", nullable: false),
                    answer_on = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "comments_answer_on_fkey",
                        column: x => x.answer_on,
                        principalTable: "comments",
                        principalColumn: "comment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "comments_pet_id_fkey",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "pet_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet_photos",
                columns: table => new
                {
                    photo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    path = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    pet_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pet_photos_pkey", x => x.photo_id);
                    table.ForeignKey(
                        name: "pet_photos_pet_id_fkey",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "pet_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet_status",
                columns: table => new
                {
                    PetsPetId = table.Column<int>(type: "integer", nullable: false),
                    StatusesStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_status", x => new { x.PetsPetId, x.StatusesStatusId });
                    table.ForeignKey(
                        name: "FK_pet_status_pets_PetsPetId",
                        column: x => x.PetsPetId,
                        principalTable: "pets",
                        principalColumn: "pet_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_status_statuses_StatusesStatusId",
                        column: x => x.StatusesStatusId,
                        principalTable: "statuses",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_city_id",
                table: "addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_country_id",
                table: "cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_answer_on",
                table: "comments",
                column: "answer_on");

            migrationBuilder.CreateIndex(
                name: "IX_comments_pet_id",
                table: "comments",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_user_receiver_id",
                table: "messages",
                column: "user_receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_user_sender_id",
                table: "messages",
                column: "user_sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_photos_pet_id",
                table: "pet_photos",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_status_StatusesStatusId",
                table: "pet_status",
                column: "StatusesStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_pets_address_id",
                table: "pets",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_user_id",
                table: "pets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_address_UsersUserId",
                table: "user_address",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "pet_photos");

            migrationBuilder.DropTable(
                name: "pet_status");

            migrationBuilder.DropTable(
                name: "user_address");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
