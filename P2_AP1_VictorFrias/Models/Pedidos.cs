using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_VictorFrias.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidosId { get; set; }

        public string NombreCliente { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

      
        public virtual ICollection<PedidosDetalle> PedidosDetalles { get; set; } = new List<PedidosDetalle>();
    }
}
