using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio{
    public class TipoFormacionRepositorio : Repositorio<TipoFormacion>, ITipoFormacionRepositorio {
        private CSACVMContext _db;
        public TipoFormacionRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(TipoFormacion obj)
        {
            _db.TipoFormacion.Update(obj);
        }

        public IEnumerable<SelectListItem> ObtenerTipoFormacion() {
            return from d in _db.TipoFormacion
                   select new SelectListItem {
                       Text = d.Descripcion,
                       Value = d.IdTipoFormacion.ToString()
                   };
        }
    }
}
