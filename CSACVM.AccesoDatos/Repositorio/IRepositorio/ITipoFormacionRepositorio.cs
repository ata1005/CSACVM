using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface ITipoFormacionRepositorio : IRepositorio<TipoFormacion> {
        void Update(TipoFormacion obj);

        public IEnumerable<SelectListItem> ObtenerTipoFormacion();
    }
}
