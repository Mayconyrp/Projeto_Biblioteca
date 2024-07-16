using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;
using System.Runtime.Intrinsics.Arm;

namespace ProjetoBiblioteca.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }



    }
}
