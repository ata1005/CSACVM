using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class IdiomaCV : DatosAuditoria {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIdiomaCV { get; set; }

        public int IdIdioma { get; set; }
        [ForeignKey("IdIdioma")]
        public Idioma Idioma { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [MaxLength(50)]
        public string Nivel { get; set; }

        public string Centro { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int? IdCurriculum { get; set; }
        [ForeignKey("IdCurriculum")]
        public Curriculum? Curriculum { get; set; }

    }
}
