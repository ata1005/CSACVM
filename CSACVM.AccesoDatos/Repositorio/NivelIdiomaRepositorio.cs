using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio{
    public class NivelIdiomaRepositorio : Repositorio<NivelIdioma>, INivelIdiomaRepositorio {
        private CSACVMContext _db;
        public NivelIdiomaRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(NivelIdioma obj)
        {
            _db.NivelIdioma.Update(obj);
        }

        public IEnumerable<SelectListItem> ObtenerNivelIdioma() {
            return from d in _db.NivelIdioma
                   select new SelectListItem {
                       Text = d.Descripcion,
                       Value = d.idNivelIdioma.ToString()
                   };
        }
    }
}
