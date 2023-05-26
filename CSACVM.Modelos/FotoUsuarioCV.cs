using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class FotoUsuarioCV : DatosAuditoria {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFotoUsuarioCV { get; set; }

        public string? Ruta { get; set; }
        public string? Ext { get; set; }
        [MaxLength(36)]
        public string? Guid { get; set;}
        public int? IdCurriculum { get; set; }
        [ForeignKey("IdCurriculum")]
        public Curriculum? Curriculum { get; set; }
    }
}
