using Bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Database
{
    public class BookstoreDbContext : IdentityDbContext<Client>
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<ShoppingCart> ShopingCarts { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<BookAuthor>()
                .HasKey(i => new { i.BookId, i.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.BookAuthors)
                .HasForeignKey(bc => bc.AuthorId);


            modelBuilder
                .Entity<Order>()
                .HasOne(i => i.Client)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.ClientId);

            modelBuilder
               .Entity<Author>()
               .HasIndex(p => new { p.Name, p.Surname }).IsUnique();

            modelBuilder
               .Entity<Category>()
               .HasIndex(p => new { p.Title }).IsUnique();

            modelBuilder
               .Entity<PublishingHouse>()
               .HasIndex(p => new { p.Title }).IsUnique();

        }
    }
}
