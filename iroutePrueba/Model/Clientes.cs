using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iroutePrueba.MODEL
{
    [Table("tbl_clientes")]
    public class Clientes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("primer_nombre")]
        public string primerNombre { get; set; }
        [Column("segundo_nombre")]
        public string segundoNombre { get; set; }
        [Column("apellidos")]
        public string apellidos { get; set; }
        [Column("identificacion")]
        public string identificacion { get; set; }
        [Column("correo")]
        public string correo { get; set; }
        [Column("estado")]
        public bool estado { get; set; }
    }
}
