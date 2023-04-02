using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class BusquedaFiltros {

        public string? filtroNombre { get; set; }
        public string? filtroProfesion { get; set; }
        public int? filtroFechaNacimientoDesde { get; set; }
        public int? filtroFechaNacimientoHasta { get; set; }
        public int? filtroIdioma { get; set; }
        public int? filtroNivelIdioma { get; set; }
        public int? filtroTipoFormacion { get; set; }
    }
}
