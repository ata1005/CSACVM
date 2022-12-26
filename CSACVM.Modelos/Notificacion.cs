﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class Notificacion {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNotificacion { get; set; }

        [ForeignKey("IdTipoNotificacion")]
        public TipoNotificacion TipoNotificacion { get; set; }

        [Required]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        public Boolean Leido { get; set; } = false;

        public DateTime FechaCreacion { get; set; }
    }
}
