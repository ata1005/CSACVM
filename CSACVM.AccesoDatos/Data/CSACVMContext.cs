using CSACVM.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSACVM.AccesoDatos.Data
{
    public class CSACVMContext : DbContext
    {
        public readonly IConfiguration _configuration;
        public CSACVMContext(DbContextOptions<CSACVMContext> options, IConfiguration configuration) : base(options){
           _configuration = configuration;
        }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<EntradaCV> EntradaCV { get; set; }
        public DbSet<EventosUsuario> EventosUsuario { get; set; }
        public DbSet<ExtraCV> ExtraCV { get; set; }
        public DbSet<ExtraEntradasCV> ExtraEntradasCV { get; set; }
        public DbSet<FormacionCV> FormacionCV { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Idioma> Idioma { get; set; }
        public DbSet<IdiomaCV> IdiomaCV { get; set; }
        public DbSet<NotasUsuario> NotasUsuario { get; set; }
        public DbSet<Notificacion> Notificacion { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<TipoEntrada> TipoEntrada { get; set; }
        public DbSet<TipoExtraCV> TipoExtraCV { get; set; }
        public DbSet<TipoNotificacion> TipoNotificacion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioCV> UsuarioCV { get; set; }
        public DbSet<FotoUsuarioCV> FotoUsuarioCV { get; set; }
        public DbSet<Curriculum> Curriculum { get; set; }

    }
}
