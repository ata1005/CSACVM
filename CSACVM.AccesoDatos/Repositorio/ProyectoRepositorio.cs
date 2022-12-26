using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class ProyectoRepositorio : Repositorio<Proyecto>, IProyectoRepositorio
    {
        private CSACVMContext _db;
        public ProyectoRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Proyecto obj)
        {
            _db.Proyecto.Update(obj);
        }
    }
}
