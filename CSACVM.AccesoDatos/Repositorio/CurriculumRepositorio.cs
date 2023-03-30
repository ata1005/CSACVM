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

        public void GuardarNuevoCurriculum(string titulo, int idUsuario) {
            Curriculum curriculum = new Curriculum() {
                Titulo = titulo,
                FechaCreacion = DateTime.Now,
                IdUsuario = idUsuario,
                ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                FechaCurriculum = DateTime.Now
            };
            _db.Curriculum.Add(curriculum);
            _db.SaveChanges();
        }

        public void EliminarCurriculum(Curriculum curriculum) {
            _db.Curriculum.Remove(curriculum);
            _db.SaveChanges();
        }

        public void ActualizarNombre(Curriculum curriculum, CurriculumModelVM model) {
            curriculum.Titulo= model.Titulo;
            curriculum.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
            curriculum.FechaActualizacion = DateTime.Now;
        }



    }
}
