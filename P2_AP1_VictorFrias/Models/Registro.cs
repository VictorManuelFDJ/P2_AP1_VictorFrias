using System.ComponentModel.DataAnnotations;

namespace P2_AP1_VictorFrias.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }
    }
}
