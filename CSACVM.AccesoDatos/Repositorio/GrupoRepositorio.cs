using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class GrupoRepositorio : Repositorio<Grupo>, IGrupoRepositorio
    {
        private CSACVMContext _db;
        public GrupoRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Grupo obj)
        {
            _db.Grupo.Update(obj);
        }
    }
}
