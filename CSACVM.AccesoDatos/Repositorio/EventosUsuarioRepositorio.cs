using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class EventosUsuarioRepositorio : Repositorio<EventosUsuario>, IEventosUsuarioRepositorio
    {
        private CSACVMContext _db;
        public EventosUsuarioRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(EventosUsuario obj)
        {
            _db.EventosUsuario.Update(obj);
        }
    }
}
