using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class CurriculumAdminVM {
        
        public List<DatatableCurriculumAdminVM>? ListaCurriculums { get; set; }
        public IEnumerable<SelectListItem>? ListaIdioma { get; set; }
        public IEnumerable<SelectListItem>? ListaNivelIdioma { get; set; }
        public IEnumerable<SelectListItem>? ListaTipoFormacion { get; set; }

    }
}

