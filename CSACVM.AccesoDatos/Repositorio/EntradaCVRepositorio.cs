using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class EntradaCVRepositorio : Repositorio<EntradaCV>, IEntradaCVRepositorio
    {
        private CSACVMContext _db;
        public EntradaCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(EntradaCV obj)
        {
            _db.EntradaCV.Update(obj);
        }
    }
}
