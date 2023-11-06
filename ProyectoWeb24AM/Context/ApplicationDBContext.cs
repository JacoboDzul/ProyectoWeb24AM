using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProyectoWeb24AM.Models.Entities;

namespace ProyectoWeb24AM.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Articulo> Articulo { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert en la tabla rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PKRol = 1,
                    Nombre = "Admin"
                },
                new Rol
                {
                    PKRol = 2,
                    Nombre = "SA"
                });

            //Insert en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PKUsuario = 1,
                    Nombre = "Jacob",
                    Apellido = "Dzul",
                    UserName = "MurderBunny",
                    Password = "1501",
                    FKRol = 1
                });
        }
    }
}
