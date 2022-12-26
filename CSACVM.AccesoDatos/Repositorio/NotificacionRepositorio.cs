using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class NotificacionRepositorio : Repositorio<Notificacion>, INotificacionRepositorio
    {
        private CSACVMContext _db;
        public NotificacionRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Notificacion obj)
        {
            _db.Notificacion.Update(obj);
        }
    }
}
