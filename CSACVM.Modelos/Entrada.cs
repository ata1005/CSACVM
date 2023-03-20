using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class Entrada : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEntrada { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public int IdTipoEntrada { get; set; }

        [ForeignKey("IdTipoEntrada")]
        public TipoEntrada TipoEntrada { get; set; }
        public int IdProyecto { get; set; }

        [ForeignKey("IdProyecto")]
        public Proyecto Proyecto { get; set; }

        [MaxLength(10)]
        public string? Lenguaje { get; set; }

        [MaxLength(50)]
        public string? TituloIssue { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }

        public Boolean Editada { get; set; } = false;

        public Boolean Resuelta { get; set; } = false;

        public int NumRespuestas { get; set; }

    }
}
