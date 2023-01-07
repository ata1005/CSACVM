using CSACVM.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.Modelos.ViewModels {
    public class RegisterVM : LoginVM {
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
        public IEnumerable<SelectListItem> ListaDepartamentos { get; set; }
        [Required]
        public int IdDepartamento { get; set; }
        public string Email { get; set; }
        public bool Administrador { get; set; }
        public IEnumerable<LoginVM> LoginVMs { get; set; }  

    }
}
