using CSACVM.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUnitOfWork{
        IUsuarioRepositorio Usuario { get; }
        IUsuarioCVRepositorio UsuarioCV { get; }
        IDepartamentoRepositorio Departamento { get; }
        IEntradaRepositorio Entrada { get; }
        IEntradaCVRepositorio EntradaCV { get; }
        IEventosUsuarioRepositorio EventosUsuario { get; }
        IAptitudCVRepositorio AptitudCV { get; }
        ILogroCVRepositorio LogroCV { get; }
        IFormacionCVRepositorio FormacionCV { get; }
        IGrupoRepositorio Grupo { get; }
        IIdiomaRepositorio Idioma { get; }
        IIdiomaCVRepositorio IdiomaCV { get; }
        INotasUsuarioRepositorio NotasUsuario { get; }
        INotificacionRepositorio Notificacion { get; }
        IProyectoRepositorio Proyecto { get; }
        IRespuestaRepositorio Respuesta { get; }
        IRolRepositorio Rol { get; }
        ITipoEntradaRepositorio TipoEntrada { get; }
        ITipoNotificacionRepositorio TipoNotificacion { get; }
        ICurriculumRepositorio Curriculum { get; }
        IFotoUsuarioCVRepositorio FotoUsuarioCV { get; }
        ITipoFormacionRepositorio TipoFormacion { get; }
        INivelIdiomaRepositorio NivelIdioma { get; }
        Microsoft.EntityFrameworkCore.DbContext GetContext();
        void Save();
    }
}