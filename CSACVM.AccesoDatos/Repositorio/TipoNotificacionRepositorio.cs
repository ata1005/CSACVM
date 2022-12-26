using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class TipoNotificacionRepositorio : Repositorio<TipoNotificacion>, ITipoNotificacionRepositorio
    {
        private CSACVMContext _db;
        public TipoNotificacionRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(TipoNotificacion obj)
        {
            _db.TipoNotificacion.Update(obj);
        }
    }
}
