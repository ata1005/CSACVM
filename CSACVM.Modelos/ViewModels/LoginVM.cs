using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class LoginVM {
        [Required(ErrorMessage = "El Usuario no puede estar vacío")]
        public string NombreUser { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La Contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

