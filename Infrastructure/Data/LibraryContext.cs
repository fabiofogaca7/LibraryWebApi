using System.Security.Cryptography.X509Certificates;
using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Book { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Dom Quixote", Author = "Miguel de Cervantes", CreatedDate = DateTime.Now.AddMonths(-6) },
            new Book { Id = 2, Title = "Cem Anos de Solidão", Author = "Gabriel García Márquez", CreatedDate = DateTime.Now.AddMonths(-3) },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", CreatedDate = DateTime.Now.AddMonths(-1) },
            new Book { Id = 4, Title = "Fogo & Sangue", Author = "Geaorge R.R. Martin", CreatedDate = DateTime.Now.AddMonths(-8) },
            new Book { Id = 5, Title = "O Acerto de Contas de Uma Mãe", Author = "Sue Klebold", CreatedDate = DateTime.Now.AddMonths(-2) },
            new Book { Id = 6, Title = "Poesias", Author = "Edgar Allan Poe", CreatedDate = DateTime.Now.AddMonths(-1) }
        );

        base.OnModelCreating(modelBuilder);
    }
}
