using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IIdiomaRepositorio : IRepositorio<Idioma> {
        void Update(Idioma obj);

        public IEnumerable<SelectListItem> ObtenerIdiomas();
    }
}
