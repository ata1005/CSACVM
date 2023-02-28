using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class ExtraCV : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExtraCV { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public int IdTipoExtraCV { get; set; }
        [ForeignKey("IdTipoExtraCV")]
        public TipoExtraCV TipoExtraCV { get; set; }
        public int? IdCurriculum { get; set; }
        [ForeignKey("IdCurriculum")]
        public Curriculum? Curriculum { get; set; }

    }
}
