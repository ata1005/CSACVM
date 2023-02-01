using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class NotasUsuario {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotaUsuario { get; set; }

        public int IdUsuario { get; set; }
        [Required]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        
        [MaxLength(100)]
        public string? Descripcion { get; set; }

        [Required]
        [MaxLength(20)]
        public string Titulo { get; set; }

    }
}
