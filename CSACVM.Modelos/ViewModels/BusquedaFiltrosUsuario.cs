using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class BusquedaFiltrosUsuario {

        public string? filtroNombre { get; set; }
        public string? filtroLogin { get; set; }
        public string? filtroApellido { get; set; }
        public bool? filtroAdmin { get; set; }
        public bool? filtroActivo { get; set; }
        public bool? filtroTodos { get; set; }

    }
}
