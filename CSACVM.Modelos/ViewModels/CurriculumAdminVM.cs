﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.Modelos.ViewModels {
    public class CurriculumAdminVM {
        
        public List<Curriculum>? ListaCurriculums { get; set; }
        public string? Titulo { get; set; }
    }
}

