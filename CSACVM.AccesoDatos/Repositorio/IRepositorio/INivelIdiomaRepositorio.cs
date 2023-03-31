using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface INivelIdiomaRepositorio : IRepositorio<NivelIdioma> {
        void Update(NivelIdioma obj);

        public IEnumerable<SelectListItem> ObtenerNivelIdioma();
    }
}
