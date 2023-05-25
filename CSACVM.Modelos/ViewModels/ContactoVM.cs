using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class ContactoVM {
        
        public List<DatatableBuscarUsuarioVM>? ListaContactos { get; set; }
        public List<DatatableBuscarUsuarioVM>? ListaUsuarios { get; set; }

    }
}

