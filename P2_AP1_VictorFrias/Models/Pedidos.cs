using System.ComponentModel.DataAnnotations;

namespace P2_AP1_VictorFrias.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidosId { get; set; }

        public string NombreCliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int Total { get; set;}


    }
}
