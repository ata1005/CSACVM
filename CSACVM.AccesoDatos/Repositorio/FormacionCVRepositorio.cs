using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio{
    public class FormacionCVRepositorio : Repositorio<FormacionCV>, IFormacionCVRepositorio
    {
        private CSACVMContext _db;
        public FormacionCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(FormacionCV obj)
        {
            _db.FormacionCV.Update(obj);
        }

        public List<FormacionCV> ObtenerListaFormacion(int idCurriculum) => _db.FormacionCV.Where(f => f.IdCurriculum== idCurriculum).ToList();
    }
}
