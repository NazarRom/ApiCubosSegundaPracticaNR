using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCubosSegundaPracticaNR.Models
{
    [Table("USUARIOSCUBO")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id_Usuario { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Pass")]
        public string Pass { get; set; }
        [Column("Imagen")]
        public string Imagen { get; set; }
    }
}
