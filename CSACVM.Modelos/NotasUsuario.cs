using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class NotasUsuario : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotaUsuario { get; set; }

        public int IdUsuario { get; set; }
        [Required]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        
        [MaxLength(100)]
        public string? Descripcion { get; set; }

        [Required]
        [MaxLength(40)]
        public string Titulo { get; set; }

    }
}
