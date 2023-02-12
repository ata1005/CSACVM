using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class CurriculumModelVM {
        
        public int IdCurriculum { get; set; }
        public string Titulo { get; set; }
        public UsuarioCV UsuarioCV { get; set; }
        public FormacionCV FormacionCV { get; set; }
        public IdiomaCV IdiomaCV { get; set; }
        public EntradaCV EntradaCV { get; set; }
        public ExtraCV ExtraCV { get; set; }
        
    }
}

