using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class ExtraCV {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExtraCV { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdTipoExtraCV")]
        public TipoExtraCV TipoExtraCV { get; set; }
        
    }
}
