using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class ExtraCVRepositorio : Repositorio<ExtraCV>, IExtraCVRepositorio
    {
        private CSACVMContext _db;
        public ExtraCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(ExtraCV obj)
        {
            _db.ExtraCV.Update(obj);
        }
    }
}
