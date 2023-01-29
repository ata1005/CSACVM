using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSACVM.Modelos {
    public class Usuario {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [Required]
        public string NombreUser { get; set;}
        public string? Nombre { get; set;}
        public string? Apellido { get; set;}
        [Required]
        public string Password { get; set;}
        public int IdRol { get; set;}
        [ForeignKey("IdRol")]
        public Rol? Rol { get; set;}
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set;}
        public int IdGrupo { get; set;}
        [ForeignKey("IdGrupo")]
        public Grupo? Grupo { get; set;}
        public byte[]? Foto { get; set;}
        public string? Email { get; set;}
        public string? Biografia { get; set;}
        public bool Activo { get; set; } = true;
        public bool EsAdmin { get; set; } = false;
    }
}