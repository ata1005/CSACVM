using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class UsuarioCVRepositorio : Repositorio<UsuarioCV>, IUsuarioCVRepositorio
    {
        private CSACVMContext _db;
        public UsuarioCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(UsuarioCV obj)
        {
            _db.UsuarioCV.Update(obj);
        }
    }
}
