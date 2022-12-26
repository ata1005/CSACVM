using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class TipoExtraCV {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoExtraCV { get; set; }
        public string Descripcion { get; set; }
    }
}
