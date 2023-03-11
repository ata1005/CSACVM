using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class CurriculumModelVM {
        
        public int IdCurriculum { get; set; }
        public string? Titulo { get; set; }
        public string? Foto { get; set; }
        public UsuarioCV? UsuarioCV { get; set; }
        public List<FormacionCV> ListaFormacionCV { get; set; }
        public List<IdiomaCV> ListaIdiomaCV { get; set; }
        public List<EntradaCV> ListaEntradaCV { get; set; }
        public List<AptitudCV> ListaAptitudCV { get; set; }
        public List<LogroCV> ListaLogroCV { get; set; }
        
    }
}

