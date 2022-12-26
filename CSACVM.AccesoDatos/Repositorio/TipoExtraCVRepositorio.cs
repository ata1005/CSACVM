using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class TipoExtraCVRepositorio : Repositorio<TipoExtraCV>, ITipoExtraCVRepositorio
    {
        private CSACVMContext _db;
        public TipoExtraCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(TipoExtraCV obj)
        {
            _db.TipoExtraCV.Update(obj);
        }
    }
}
