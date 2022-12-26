using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUnitOfWork{
        IUsuarioRepositorio Usuario { get; }
        IDepartamentoRepositorio Departamento { get; }
        IEntradaRepositorio Entrada { get; }
        IEntradaCVRepositorio EntradaCV { get; }
        IEventosUsuarioRepositorio EventosUsuario { get; }
        IExtraCVRepositorio ExtraCV { get; }
        IExtraEntradasCVRepositorio ExtraEntradasCV { get; }
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
        ITipoExtraCVRepositorio TipoExtraCV { get; }
        ITipoNotificacionRepositorio TipoNotificacion { get; }
        Microsoft.EntityFrameworkCore.DbContext GetContext();
        void Save();
    }
}