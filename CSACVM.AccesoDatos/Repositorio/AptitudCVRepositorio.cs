using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

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

        public void GuardarAptitud(List<AptitudCV> lstAptitudCV, List<string> lstDescripcionAptitud, int idCurriculum, int idUser) {
            List<string> descripcionNueva= new List<string>();

            foreach (AptitudCV aptitud in lstAptitudCV) {
                descripcionNueva.Add(aptitud.Descripcion);
                if (!lstDescripcionAptitud.Contains(aptitud.Descripcion)) {
                    _db.AptitudCV.Remove(aptitud);
                    _db.SaveChanges();
                } 
            }

            foreach(string desc in lstDescripcionAptitud) {
                if(!descripcionNueva.Contains(desc)) {
                    AptitudCV aptitud = new AptitudCV() {
                        Descripcion = desc,
                        IdCurriculum = idCurriculum,
                        ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacion = idUser
                    };
                    _db.AptitudCV.Add(aptitud);
                    _db.SaveChanges();
                }
            }
        }
        public void EliminarAptitud(AptitudCV aptitudCV) {
            _db.AptitudCV.Remove(aptitudCV);
            _db.SaveChanges();
        }

        public void ClonadoAptitudCV(Curriculum clonado, CurriculumModelVM model) {
            foreach (AptitudCV aptitud in model.ListaAptitudCV) {
                AptitudCV nueva = new AptitudCV() {
                    IdCurriculum = clonado.IdCurriculum,
                    Descripcion = aptitud.Descripcion,
                    FechaCreacion = DateTime.Now,
                    ProcesoCreacion = MethodBase.GetCurrentMethod().Name
                };

                _db.AptitudCV.Add(nueva);
                _db.SaveChanges();
            }
        }

    }
}
