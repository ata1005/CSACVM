using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class Contacto : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public int IdUsuarioAgregado { get; set; }
        
    }
}
