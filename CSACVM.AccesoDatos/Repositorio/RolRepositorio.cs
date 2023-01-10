using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSACVM.AccesoDatos.Repositorio{
    public class RolRepositorio : Repositorio<Rol>, IRolRepositorio
    {
        private CSACVMContext _db;
        public RolRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Rol obj)
        {
            _db.Rol.Update(obj);
        }
        public IEnumerable<SelectListItem> ObtenerRoles() {
            return from d in _db.Rol
                   select new SelectListItem {
                       Text = d.Descripcion,
                       Value = d.IdRol.ToString()
                   };
        }
    }
}
