using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class IdiomaCVRepositorio : Repositorio<IdiomaCV>, IIdiomaCVRepositorio
    {
        private CSACVMContext _db;
        public IdiomaCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(IdiomaCV obj)
        {
            _db.IdiomaCV.Update(obj);
        }
    }
}
