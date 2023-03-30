using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

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

        public void GuardarLogro(List<LogroCV> lstLogroCV, List<string> lstDescripcionLogro, int idCurriculum, int idUser) {
            List<string> descripcionNueva = new List<string>();

            foreach (LogroCV logro in lstLogroCV) {
                descripcionNueva.Add(logro.Descripcion);
                if (!lstDescripcionLogro.Contains(logro.Descripcion)) {
                    _db.LogroCV.Remove(logro);
                    _db.SaveChanges();
                }
            }

            foreach (string desc in lstDescripcionLogro) {
                if (!descripcionNueva.Contains(desc)) {
                    LogroCV logro = new LogroCV() {
                        Descripcion = desc,
                        IdCurriculum = idCurriculum,
                        ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacion = idUser
                    };
                    _db.LogroCV.Add(logro);
                    _db.SaveChanges();
                }
            }
        }
        public void EliminarLogro(LogroCV logroCV) {
            _db.LogroCV.Remove(logroCV);
            _db.SaveChanges();
        }

        public void ClonadoLogroCV(Curriculum clonado, CurriculumModelVM model) {
            foreach (LogroCV logro in model.ListaLogroCV) {
                LogroCV nueva = new LogroCV() {
                    IdCurriculum = clonado.IdCurriculum,
                    Descripcion = logro.Descripcion,
                    FechaCreacion = DateTime.Now,
                    ProcesoCreacion = MethodBase.GetCurrentMethod().Name
                };

                _db.LogroCV.Add(nueva);
                _db.SaveChanges();
            }
        }

    }
}
