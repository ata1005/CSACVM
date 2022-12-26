using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        private CSACVMContext _db;
        public DepartamentoRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Departamento obj)
        {
            _db.Departamento.Update(obj);
        }
    }
}
