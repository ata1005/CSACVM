﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCC_Workflow.Modelos;

namespace CSACVM.Modelos {
    public class UsuarioCV : DatosAuditoria {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioCV { get; set; }

        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        [Required]
        public Usuario Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Profesion { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Email { get; set; }
        public int? IdFotoUsuarioCV { get; set; }
        [ForeignKey("IdFotoUsuarioCV")]
        public FotoUsuarioCV? FotoUsuarioCV { get; set; }
        public int? Telefono { get; set; }
        public string? EnlaceContacto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdCurriculum { get; set; }
        [ForeignKey("IdCurriculum")]
        public Curriculum? Curriculum { get; set; }
        [MaxLength(int.MaxValue)]
        public string? AcercaDe { get; set; }
    }
}
