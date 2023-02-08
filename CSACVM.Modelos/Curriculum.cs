using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class Curriculum : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurriculum { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        //public Usuario Usuario { get; set; }
        //public int IdUsuarioCV { get; set; }
        //[ForeignKey("IdUsuarioCV")]
        //public UsuarioCV UsuarioCV { get; set; }
        public DateTime? FechaCurriculum { get; set; }
        public string? Titulo { get; set; }
        //public int IdFormacionCV { get; set; }
        //[ForeignKey("IdFormacionCV")]
        //public FormacionCV FormacionCV { get; set; }
        //public int IdIdiomaCV { get; set; }
        //[ForeignKey("IdIdiomaCV")]
        //public IdiomaCV IdiomaCV { get; set; }
        //public int IdEntradaCV { get; set; }
        //[ForeignKey("IdEntradaCV")]
        //public EntradaCV EntradaCV { get; set; }
        //public int IdExtraCV { get; set; }
        //[ForeignKey("IdExtraCV")]
        //public ExtraCV ExtraCV { get; set; }


    }
}
