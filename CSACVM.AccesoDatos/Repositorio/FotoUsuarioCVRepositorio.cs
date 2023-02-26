using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class FotoUsuarioCVRepositorio : Repositorio<FotoUsuarioCV>, IFotoUsuarioCVRepositorio {
        private CSACVMContext _db;
        public FotoUsuarioCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(FotoUsuarioCV obj)
        {
            _db.FotoUsuarioCV.Update(obj);
        }
    }
}
