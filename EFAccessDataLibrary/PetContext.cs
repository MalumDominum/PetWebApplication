using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary
{
    public class PetContext : DbContext
    {
        public PetContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public PetContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetPhoto> PetPhotos { get; set; }
        public virtual DbSet<Status> States { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ApartmentNumber).HasColumnName("apartment_number");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.District)
                    .HasColumnType("character varying")
                    .HasColumnName("district");

                entity.Property(e => e.HouseNumber).HasColumnName("house_number");

                entity.Property(e => e.StreetName)
                    .HasColumnType("character varying")
                    .HasColumnName("street_name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("addresses_city_id_fkey");

                entity.HasMany(a => a.Users)
                    .WithMany(u => u.Addresses)
                    .UsingEntity(j => j.ToTable("user_address"));
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CityName)
                    .HasColumnType("character varying")
                    .HasColumnName("city_name");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Region)
                    .HasColumnType("character varying")
                    .HasColumnName("region");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("cities_country_id_fkey");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AnswerOnId).HasColumnName("answer_on");

                entity.Property(e => e.Content)
                    .HasColumnType("character varying")
                    .HasColumnName("content");

                entity.Property(e => e.AuthorId).HasColumnName("user_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.PostDate).HasColumnName("post_date");

                entity.HasOne(d => d.AnswerOn)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.AnswerOnId)
                    .HasConstraintName("comments_answer_on_fkey");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("comments_pet_id_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasColumnType("character varying")
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(10000)
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.LastUpdateAt).HasColumnName("last_update_at");

                entity.Property(e => e.UserReceiverId).HasColumnName("user_receiver_id");

                entity.Property(e => e.UserSenderId).HasColumnName("user_sender_id");

                entity.HasOne(d => d.UserReceiver)
                    .WithMany(p => p.ReceivedMessages)
                    .HasForeignKey(d => d.UserReceiverId)
                    .HasConstraintName("messages_user_reciver_id_fkey");

                entity.HasOne(d => d.UserSender)
                    .WithMany(p => p.SentMessages)
                    .HasForeignKey(d => d.UserSenderId)
                    .HasConstraintName("messages_user_sender_id_fkey");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("pets");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.Breed)
                    .HasMaxLength(255)
                    .HasColumnName("breed");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description)
                    .HasMaxLength(10000)
                    .HasColumnName("description");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.Healthy).HasColumnName("healthy");

                entity.Property(e => e.LastUpdateAt).HasColumnName("last_update_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Neutering).HasColumnName("neutering");

                entity.Property(e => e.RoughAge).HasColumnName("rough_age");

                entity.Property(e => e.Species)
                    .HasMaxLength(100)
                    .HasColumnName("species");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ViewsNumber).HasColumnName("views_number");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("pets_address_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("pets_user_id_fkey");

                entity.HasMany(p => p.Statuses)
                    .WithMany(s => s.Pets)
                    .UsingEntity(j => j.ToTable("pet_status"));
            });

            modelBuilder.Entity<PetPhoto>(entity =>
            {
                entity.HasKey(e => e.PhotoId)
                    .HasName("pet_photos_pkey");

                entity.ToTable("pet_photos");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.Property(e => e.Path)
                    .HasMaxLength(1000)
                    .HasColumnName("path");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetPhotos)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("pet_photos_pet_id_fkey");
            });

            /*modelBuilder.Entity<PetState>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pets_states");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("pets_states_pet_id_fkey");

                entity.HasOne(d => d.State)
                    .WithMany()
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("pets_states_state_id_fkey");
            });*/

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("statuses");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.HasMany(s => s.Pets)
                    .WithMany(p => p.Statuses)
                    .UsingEntity(j => j.ToTable("pet_status"));
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(u => u.UserId).HasColumnName("user_id");

                entity.Property(u => u.AddressId).HasColumnName("address_id");

                entity.Property(u => u.BirthDate).HasColumnName("birth_date");

                entity.Property(u => u.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(u => u.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.LastUpdatedAt).HasColumnName("last_updated_at");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(1000)
                    .HasColumnName("photo_path");

                entity.HasMany(u => u.Addresses)
                    .WithMany(a => a.Users)
                    .UsingEntity(j => j.ToTable("user_address"));
            });

            /*modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AddressId })
                    .HasName("user_address_pkey");

                entity.ToTable("user_address");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_address_address_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_address_user_id_fkey");
            });*/

            OnModelCreatingPartial(modelBuilder);
        }

        void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            
        }
    }
}
