using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Context
{
    public class LibroContext : DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {

        }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//aca definimos todos los metodos que alteran nuestras tablas

            //Creamos la tabla categoria
            modelBuilder.Entity<Libro>(libro =>
            {
                //Definimos que categoria será una tabla
                libro.ToTable("Libro");
                //Lave primaria
                libro.HasKey(p => p.LibroId);
                //Propiedades

                libro.Property(p => p.LibroName);
                libro.Property(p => p.LibroName);

            });
        }
    }
}
