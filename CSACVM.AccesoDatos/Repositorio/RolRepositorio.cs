using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

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
    }
}
