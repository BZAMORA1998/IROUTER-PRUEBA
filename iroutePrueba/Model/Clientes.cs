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
        public string PrimerNombre { get; set; }
        [Column("segundo_nombre")]
        public string SegundoNombre { get; set; }
        [Column("apellidos")]
        public string Apellidos { get; set; }
        [Column("identificacion")]
        public string Identificacion { get; set; }
        [Column("correo")]
        public string Correo { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
    }
}
