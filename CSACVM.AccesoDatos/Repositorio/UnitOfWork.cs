using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
namespace CSACVM.AccesoDatos.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private CSACVMContext _db;

        public UnitOfWork(CSACVMContext db) {
            _db = db;
            Usuario = new UsuarioRepositorio(_db);
            UsuarioCV = new UsuarioCVRepositorio(_db);
            Departamento = new DepartamentoRepositorio(_db);
            Entrada = new EntradaRepositorio(_db);
            EntradaCV = new EntradaCVRepositorio(_db);
            EventosUsuario = new EventosUsuarioRepositorio(_db);
            AptitudCV = new AptitudCVRepositorio(_db);
            LogroCV = new LogroCVRepositorio(_db);
            FormacionCV = new FormacionCVRepositorio(_db);
            Grupo = new GrupoRepositorio(_db);
            Idioma = new IdiomaRepositorio(_db);
            IdiomaCV = new IdiomaCVRepositorio(_db);
            NotasUsuario = new NotasUsuarioRepositorio(_db);
            Notificacion = new NotificacionRepositorio(_db);
            Proyecto = new ProyectoRepositorio(_db);
            Respuesta = new RespuestaRepositorio(_db);
            Rol = new RolRepositorio(_db);
            TipoEntrada = new TipoEntradaRepositorio(_db);
            TipoFormacion = new TipoFormacionRepositorio(_db);
            TipoNotificacion = new TipoNotificacionRepositorio(_db);
            Curriculum = new CurriculumRepositorio(_db);
            FotoUsuarioCV = new FotoUsuarioCVRepositorio(_db);
            NivelIdioma = new NivelIdiomaRepositorio(_db);
        }
        public IUsuarioRepositorio Usuario { get; private set; }
        public IUsuarioCVRepositorio UsuarioCV { get; private set; }
        public IDepartamentoRepositorio Departamento { get; private set; }
        public IEntradaRepositorio Entrada { get; private set; }
        public IEntradaCVRepositorio EntradaCV { get; private set; }
        public IEventosUsuarioRepositorio EventosUsuario { get; private set; }
        public IAptitudCVRepositorio AptitudCV { get; private set; }
        public ILogroCVRepositorio LogroCV { get; private set; }
        public IFormacionCVRepositorio FormacionCV { get; private set; }
        public IGrupoRepositorio Grupo { get; private set; }
        public IIdiomaRepositorio Idioma { get; private set; }
        public IIdiomaCVRepositorio IdiomaCV { get; private set; }
        public INotasUsuarioRepositorio NotasUsuario { get; private set; }
        public INotificacionRepositorio Notificacion { get; private set; }
        public IProyectoRepositorio Proyecto { get; private set; }
        public IRespuestaRepositorio Respuesta { get; private set; }
        public IRolRepositorio Rol { get; private set; }
        public ITipoEntradaRepositorio TipoEntrada { get; private set; }
        public ITipoNotificacionRepositorio TipoNotificacion { get; private set; }
        public ICurriculumRepositorio Curriculum { get; private set; }
        public IFotoUsuarioCVRepositorio FotoUsuarioCV { get; private set; }
        public ITipoFormacionRepositorio TipoFormacion { get; private set; }
        public INivelIdiomaRepositorio NivelIdioma { get; private set; }
        public Microsoft.EntityFrameworkCore.DbContext GetContext(){
            return this._db;
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}