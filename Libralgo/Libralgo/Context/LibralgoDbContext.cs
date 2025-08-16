using Libralgo.Models;
using Libralgo.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Libralgo.Context
{
    public class LibralgoDbContext : DbContext
    {
        public LibralgoDbContext(DbContextOptions<LibralgoDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Library> Libraries => Set<Library>();
        public DbSet<LibraryMember> LibraryMembers => Set<LibraryMember>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Author> Authors => Set<Author>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LibraryMember>()
                .HasKey(m => new { m.LibraryId, m.UserId });

            modelBuilder.Entity<LibraryMember>()
                .HasOne(m => m.Library)
                .WithMany(l => l.LibraryMembers)
                .HasForeignKey(m => m.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LibraryMember>()
                .HasOne(m => m.User)
                .WithMany(u => u.LibraryMemberships)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LibraryMember>()
                .HasOne(m => m.InvitedByUser)
                .WithMany()
                .HasForeignKey(m => m.InvitedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LibraryMember>()
                .Property(m => m.Role)
                .HasDefaultValue(LibraryMemberRole.Member);

            modelBuilder.Entity<LibraryMember>()
                .Property(m => m.Status)
                .HasDefaultValue(LibraryMemberStatus.Pending);

            // ===== Book -> Publisher (N:1) =====
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict); // yayınevi silinse kitaplar kalır

            // ===== Book -> Library (N:1) =====
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Library)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LibraryId)
                .OnDelete(DeleteBehavior.Cascade); // kütüphane silinirse kitaplar da silinsin

            // ===== Book <-> Author (N:N) =====
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthors",
                    j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("BookId", "AuthorId");
                        j.ToTable("BookAuthors");
                    }
                );

            // ===== Book <-> Category (N:N) =====
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Categories)
                .WithMany(c => c.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookCategories",
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("BookId", "CategoryId");
                        j.ToTable("BookCategories");
                    }
                );
        }
    }
}
