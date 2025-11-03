using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_VictorFrias.Models;

public class PedidosDetalle
{
    [Key]
    public  int Id {get; set;}

    public int Cantidad { get; set;}
    public int Precio { get; set;}

    [ForeignKey("PedidosId")]
    public virtual ICollection<PedidosDetalle> Detalle { get; set; } = new List<PedidosDetalle>();

}
