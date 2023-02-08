using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class CurriculumRepositorio : Repositorio<Curriculum>, ICurriculumRepositorio {
        private CSACVMContext _db;
        public CurriculumRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Curriculum obj)
        {
            _db.Curriculum.Update(obj);
        }

        public List<Curriculum> ObtenerCurriculumsUsuario(int idUsuario) => _db.Curriculum.Where(n => n.IdUsuario == idUsuario).ToList();


    }
}
