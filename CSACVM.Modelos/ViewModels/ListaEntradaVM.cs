using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class ListaEntradaVM {
        public Entrada Entrada { get; set; }
        public Usuario Usuario { get; set; }
    }
}

