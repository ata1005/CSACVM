using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class ExtraEntradasCVRepositorio : Repositorio<ExtraEntradasCV>, IExtraEntradasCVRepositorio
    {
        private CSACVMContext _db;
        public ExtraEntradasCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(ExtraEntradasCV obj)
        {
            _db.ExtraEntradasCV.Update(obj);
        }
    }
}
