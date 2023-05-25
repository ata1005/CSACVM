using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class DatatableBuscarUsuarioVM {
        
        public int? IdUsuario { get; set; }
        //Nombre y Apellidos
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Foto { get; set;}
        public string? Departamento { get; set;}
        public string? Rol { get; set;}
    }
}

