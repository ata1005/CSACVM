using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento> {
        void Update(Departamento obj);
        public IEnumerable<SelectListItem> ObtenerDepartamentos();
    }
}
