using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class LogroCVRepositorio : Repositorio<LogroCV>, ILogroCVRepositorio {
        private CSACVMContext _db;
        public LogroCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(LogroCV obj)
        {
            _db.LogroCV.Update(obj);
        }
        public List<LogroCV> ObtenerListaLogro(int idCurriculum) => _db.LogroCV.Where(f => f.IdCurriculum == idCurriculum).ToList();

    }
}
