﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos {
    public class Idioma {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIdioma { get; set; }

        [MaxLength(5)]
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
