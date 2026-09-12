using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_VictorFrias.Models
{
    public class PedidosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int PedidosId { get; set; }

        public int ComponenteId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        [ForeignKey("PedidosId")]
        public Pedidos? Pedido { get; set; }

        [ForeignKey("ComponenteId")]
        public Componente? Componente { get; set; }
    }
}
