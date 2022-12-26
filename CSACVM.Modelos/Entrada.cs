using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class Entrada {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEntrada { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdTipoEntrada")]
        public TipoEntrada TipoEntrada { get; set; }

        [ForeignKey("IdProyecto")]
        public Proyecto Proyecto { get; set; }

        [MaxLength(10)]
        public string? Lenguaje { get; set; }

        [MaxLength(50)]
        public string? TituloIssue { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Descripcion { get; set; }

        public Boolean Editada { get; set; } = false;

        public Boolean Resuelta { get; set; } = false;

        public int NumRespuestas { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
