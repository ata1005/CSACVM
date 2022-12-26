using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class EntradaRepositorio : Repositorio<Entrada>, IEntradaRepositorio
    {
        private CSACVMContext _db;
        public EntradaRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Entrada obj)
        {
            _db.Entrada.Update(obj);
        }
    }
}
