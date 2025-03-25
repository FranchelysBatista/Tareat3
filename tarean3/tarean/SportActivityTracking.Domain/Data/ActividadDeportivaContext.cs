using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportActivityTracking.Domain.Entities;

namespace SportActivityTracking.Domain.Data
{
    public class ActividadDeportivaContext : DbContext
    {
        public ActividadDeportivaContext(DbContextOptions<ActividadDeportivaContext> options)
            : base(options) { }

        public DbSet<ActividadDeportiva> ActividadesDeportivas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActividadDeportiva>().HasData(
                new ActividadDeportiva
                {
                    Id = 1,
                    Descripcion = "Carrera matutina en el parque",
                    Fecha = new DateTime(2025, 3, 24, 7, 0, 0),
                    DuracionMinutos = 45,
                    TipoDeporte = "Running",
                    Usuario = "Franyeli@gmail.com"
                },
                new ActividadDeportiva
                {
                    Id = 2,
                    Descripcion = "Sesión de natación",
                    Fecha = new DateTime(2025, 3, 23, 18, 30, 0),
                    DuracionMinutos = 60,
                    TipoDeporte = "Natación",
                    Usuario = "Franklin@gmail.com"
                },
                new ActividadDeportiva
                {
                    Id = 3,
                    Descripcion = "Partido de fútbol",
                    Fecha = new DateTime(2025, 3, 22, 16, 0, 0),
                    DuracionMinutos = 90,
                    TipoDeporte = "Fútbol",
                    Usuario = "pedro@hotmail.com"
                },
                new ActividadDeportiva
                {
                    Id = 4,
                    Descripcion = "Clases de yoga en casa",
                    Fecha = new DateTime(2025, 3, 21, 8, 0, 0),
                    DuracionMinutos = 30,
                    TipoDeporte = "Yoga",
                    Usuario = "luisafernandez@outlook.com"
                },
                new ActividadDeportiva
                {
                    Id = 5,
                    Descripcion = "Entrenamiento de fuerza en el gimnasio",
                    Fecha = new DateTime(2025, 3, 20, 19, 0, 0),
                    DuracionMinutos = 50,
                    TipoDeporte = "Gimnasio",
                    Usuario = "carlosm@gmail.com"
                },
                new ActividadDeportiva
                {
                    Id = 6,
                    Descripcion = "Ruta en bicicleta por la montaña",
                    Fecha = new DateTime(2025, 3, 19, 10, 0, 0),
                    DuracionMinutos = 120,
                    TipoDeporte = "Ciclismo",
                    Usuario = "sofiaj@yahoo.com"
                },
                new ActividadDeportiva
                {
                    Id = 7,
                    Descripcion = "Partido de baloncesto con amigos",
                    Fecha = new DateTime(2025, 3, 18, 17, 0, 0),
                    DuracionMinutos = 60,
                    TipoDeporte = "Baloncesto",
                    Usuario = "daniel@gmail.com"
                }
            );
        }
    }
}
