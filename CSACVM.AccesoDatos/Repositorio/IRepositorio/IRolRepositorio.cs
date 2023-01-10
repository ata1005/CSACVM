using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IRolRepositorio : IRepositorio<Rol> {
        void Update(Rol obj);
        public IEnumerable<SelectListItem> ObtenerRoles();
    }
}
