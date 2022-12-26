using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class NotasUsuarioRepositorio : Repositorio<NotasUsuario>, INotasUsuarioRepositorio
    {
        private CSACVMContext _db;
        public NotasUsuarioRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(NotasUsuario obj)
        {
            _db.NotasUsuario.Update(obj);
        }
    }
}
