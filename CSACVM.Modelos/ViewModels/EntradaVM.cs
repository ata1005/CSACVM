using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class EntradaVM {
        public string NombreUser { get; set; }
        public string RutaFoto { get; set; }
        public List<ListaEntradaVM> ListaEntradaVM { get; set; }
    }
}

