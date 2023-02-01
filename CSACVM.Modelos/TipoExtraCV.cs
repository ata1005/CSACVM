﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class TipoExtraCV : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoExtraCV { get; set; }
        public string Descripcion { get; set; }
    }
}
