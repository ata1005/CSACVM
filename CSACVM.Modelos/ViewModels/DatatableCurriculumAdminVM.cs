using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class DatatableCurriculumAdminVM {
        
        public int? IdCurriculum { get; set; }
        public string? Titulo { get; set; }
        public DateTime? UltimaActualizacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Profesion { get; set; }
        public List<int>? Idioma { get; set; }
        public List<int>? NivelIdioma { get; set; }
        public List<int>? TipoFormacion { get; set; }
    }
}

