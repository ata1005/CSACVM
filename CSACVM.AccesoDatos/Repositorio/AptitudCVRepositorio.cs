using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class AptitudCVRepositorio : Repositorio<AptitudCV>, IAptitudCVRepositorio
    {
        private CSACVMContext _db;
        public AptitudCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(AptitudCV obj)
        {
            _db.AptitudCV.Update(obj);
        }

        public List<AptitudCV> ObtenerListaAptitud(int idCurriculum) => _db.AptitudCV.Where(f => f.IdCurriculum == idCurriculum).ToList();

    }
}
