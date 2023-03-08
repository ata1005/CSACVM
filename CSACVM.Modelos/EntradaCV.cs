using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class EntradaCV : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEntradaCV { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [MaxLength(50)]
        public string? PuestoTrabajo { get; set; }

        [MaxLength(50)]
        public string? EmpresaAsociada { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string? Observaciones { get; set; }

        public string? Ubicacion { get; set; }

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int? IdCurriculum { get; set; }
        [ForeignKey("IdCurriculum")]
        public Curriculum? Curriculum { get; set; }
    }
}
