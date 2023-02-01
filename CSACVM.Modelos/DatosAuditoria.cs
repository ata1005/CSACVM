using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCC_Workflow.Modelos {
    public abstract class DatosAuditoria {
        public int? UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        [MaxLength(255)]
        public string? ProcesoCreacion { get; set; }
        public int? UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        [MaxLength(255)]
        public string? ProcesoActualizacion { get; set; }
    }
}
