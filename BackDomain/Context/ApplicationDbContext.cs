using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WepApi.Context
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Insert en la tabla usuario

            //modelBuilder.Entity<Usuario>().HasData(
            //    new Usuario
            //    {
            //        Id = 1,
            //        UserName = "Majo",
            //        Password = "1234"

            //    });
            //modelBuilder.Entity<Producto>().HasData(
            //    new Producto
            //    {
            //        Id = 1,
            //        Name = "Terreneitor",
            //        Description = "Carro a control remoto",
            //        Price = 599.99
            //    });
        }

    }
}
