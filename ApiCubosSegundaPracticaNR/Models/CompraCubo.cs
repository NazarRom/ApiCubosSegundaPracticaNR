using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCubosSegundaPracticaNR.Models
{
    [Table("COMPRACUBOS")]
    public class CompraCubo
    {
        [Key]
        [Column("id_pedido")]
        public int Id_Pedido { get; set; }
        [Column("id_cubo")]
        public int Id_Cubo { get; set; }
        [Column("id_usuario")]
        public int Id_Usario { get; set; }
        [Column("fechapedido")]
        public DateTime FechaPedidio { get; set; }

    }
}
