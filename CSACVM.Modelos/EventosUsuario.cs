﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class EventosUsuario : DatosAuditoria {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEventoUsuario { get; set; }

        [Required]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }


        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
