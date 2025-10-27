using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using P2_AP1_VictorFrias.Models;

namespace P2_AP1_VictorFrias.DAL;

public class Contexto : DbContext
{
   public DbSet<Registro> Registros { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options) 
    {

    }
}
