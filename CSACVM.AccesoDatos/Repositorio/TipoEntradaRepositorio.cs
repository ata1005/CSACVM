using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class TipoEntradaRepositorio : Repositorio<TipoEntrada>, ITipoEntradaRepositorio
    {
        private CSACVMContext _db;
        public TipoEntradaRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(TipoEntrada obj)
        {
            _db.TipoEntrada.Update(obj);
        }
    }
}
