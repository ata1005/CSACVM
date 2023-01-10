using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class CookieUserItem {
        public int IdUsuario { get; set; }
        public string NombreUser { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int IdDepartamento { get; set; }
        public int? IdGrupo { get; set; }
        public int? IdRol { get; set; }
        public bool Administrador { get; set; }
    }
}
