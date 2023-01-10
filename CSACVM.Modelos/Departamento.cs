using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class Departamento {


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDepartamento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        public string? Codigo { get; set; }
    }
}
