using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class RespuestaRepositorio : Repositorio<Respuesta>, IRespuestaRepositorio
    {
        private CSACVMContext _db;
        public RespuestaRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Respuesta obj)
        {
            _db.Respuesta.Update(obj);
        }
    }
}
