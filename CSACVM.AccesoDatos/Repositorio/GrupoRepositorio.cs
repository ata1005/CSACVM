using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio{
    public class GrupoRepositorio : Repositorio<Grupo>, IGrupoRepositorio
    {
        private CSACVMContext _db;
        public GrupoRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Grupo obj)
        {
            _db.Grupo.Update(obj);
        }
        public IEnumerable<SelectListItem> ObtenerGrupos() {
            return from d in _db.Grupo
                   select new SelectListItem {
                       Text = d.Descripcion,
                       Value = d.IdGrupo.ToString()
                   };
        }
    }
}
