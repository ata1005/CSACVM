﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class FormacionCV {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFormacionCV { get; set; }
        
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public string Grado { get; set; }
        public string Ubicacion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

    }
}
