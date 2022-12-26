using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private CSACVMContext _db;
        public UsuarioRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }

        public bool EsAdmin(int idUsuario) => _db.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario).EsAdmin;
        

        public void Update(Usuario obj)
        {
            _db.Usuario.Update(obj);
        }
    }
}
