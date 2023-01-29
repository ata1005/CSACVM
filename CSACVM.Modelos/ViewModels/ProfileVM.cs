using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class ProfileVM {
        [Required(ErrorMessage = "La contraseña actual no puede estar vacía")]
        [DataType(DataType.Password)]
        public string PassActual { get; set; }
        [Required(ErrorMessage = "La nueva contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string? Biografia { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string NombreUser { get; set; }
        public string Dpto { get; set; }
    }
}

