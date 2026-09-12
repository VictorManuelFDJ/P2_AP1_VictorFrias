using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using P2_AP1_VictorFrias.Models;

namespace P2_AP1_VictorFrias.DAL;

public class Contexto : DbContext
{
   public DbSet<Pedidos> Pedidos {get; set;}
   public DbSet<PedidosDetalle> PedidosDetalles {get; set;}
   public DbSet<Componente> Componentes { get; set;}

    public Contexto(DbContextOptions<Contexto> options) : base(options) 
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Componente>().HasData(
            new List<Componente>()
            {
            new()
            {
                ComponenteId = 1,
                Descripcion = "Teclado",
                Existencia = 0,
            },
            new()
            {
                ComponenteId = 2,
                Descripcion = "Procesador",
                Existencia = 0,
            },
            new()
            {
                ComponenteId = 3,
                Descripcion = "HDI",
                Existencia = 0,
            },
            new()
            {
                ComponenteId = 4,
                Descripcion = "Cable sata",
                Existencia = 0,
            },
            new()
            {
                ComponenteId = 5,
                Descripcion = "Ram",
                Existencia = 0,
            },
            new()
            {
                ComponenteId = 6,
                Descripcion = "Disco duro",
                Existencia = 0,
            }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
