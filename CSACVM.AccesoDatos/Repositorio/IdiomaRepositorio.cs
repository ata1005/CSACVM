using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio{
    public class IdiomaRepositorio : Repositorio<Idioma>, IIdiomaRepositorio
    {
        private CSACVMContext _db;
        public IdiomaRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Idioma obj)
        {
            _db.Idioma.Update(obj);
        }

        public IEnumerable<SelectListItem> ObtenerIdiomas() {
            return from d in _db.Idioma
                   select new SelectListItem {
                       Text = d.Descripcion,
                       Value = d.IdIdioma.ToString()
                   };
        }
    }
}
