using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class DatatableUsuarioAdminVM {
        
        public int? IdUsuario { get; set; }
        public bool Activo { get; set; } = true;
        public bool EsAdmin { get; set; } = false;
        public string NombreUser { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }
}

