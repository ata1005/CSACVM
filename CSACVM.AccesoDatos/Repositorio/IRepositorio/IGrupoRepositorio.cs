using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IGrupoRepositorio : IRepositorio<Grupo> {
        void Update(Grupo obj);
        public IEnumerable<SelectListItem> ObtenerGrupos();
    }
}
