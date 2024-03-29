﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class Grupo : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
