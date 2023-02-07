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
        public int IdUsuarioCV { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public byte[]? Foto { get; set; }
        public string? Ruta { get; set; }
        [MaxLength(32)]
        public string? Guid { get; set;}
    }
}
