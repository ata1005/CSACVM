using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio {
    public class DatatableCurriculumAdminVMRepositorio : Repositorio<DatatableCurriculumAdminVM>, IDatatableCurriculumAdminVMRepositorio {
        private readonly CSACVMContext _db;

        public DatatableCurriculumAdminVMRepositorio(CSACVMContext db) : base(db) {
            _db = db;
        }

        public List<DatatableCurriculumAdminVM> ObtenerCurriculums(BusquedaFiltros filtros) {

            List<DatatableCurriculumAdminVM> listaCurriculums = new List<DatatableCurriculumAdminVM>();

            List<Curriculum> lstCurriculums = _db.Curriculum.ToList();

            //Obtenemos todos los currículums con todos los datos;
            foreach (Curriculum curriculum in lstCurriculums) {
                UsuarioCV usuario = _db.UsuarioCV.Where(u => u.IdCurriculum == curriculum.IdCurriculum).FirstOrDefault();
                List<int> lstIdioma = _db.IdiomaCV.Where(i => i.IdCurriculum == curriculum.IdCurriculum).Select(i2 => Convert.ToInt32(i2.IdIdioma)).ToList();
                List<int> lstNivelIdioma = _db.IdiomaCV.Where(n => n.IdCurriculum == curriculum.IdCurriculum).Select(n2 => Convert.ToInt32(n2.IdNivelIdioma)).ToList();
                List<int> lstTipoFormacion = _db.FormacionCV.Where(f => f.IdCurriculum == curriculum.IdCurriculum).Select(f2 => Convert.ToInt32(f2.IdTipoFormacion)).ToList();
                DatatableCurriculumAdminVM model = new DatatableCurriculumAdminVM() {
                    IdCurriculum = curriculum.IdCurriculum,
                    Titulo = curriculum.Titulo,
                    UltimaActualizacion = curriculum.FechaActualizacion != null ? curriculum.FechaActualizacion : curriculum.FechaCurriculum,
                    NombreCompleto = usuario.Nombre + " " + usuario.Apellido1 + " " + usuario.Apellido2,
                    Profesion = usuario.Profesion,
                    Idioma = lstIdioma,
                    TipoFormacion = lstTipoFormacion,
                    NivelIdioma = lstNivelIdioma,
                    FechaNacimiento = usuario.FechaNacimiento
                };
                listaCurriculums.Add(model);
            }

            
           
            

            //Filtros
            if (filtros.filtroNombre != null) {
                listaCurriculums = listaCurriculums.Where(fN => fN.NombreCompleto.Trim().ToUpper().Contains(filtros.filtroNombre.Trim().ToUpper())).ToList();
            }
            if(filtros.filtroProfesion != null) {
                listaCurriculums = listaCurriculums.Where(fP => fP.Profesion.Trim().ToUpper().Contains(filtros.filtroProfesion.Trim().ToUpper())).ToList();
            }
            if (filtros.filtroFechaNacimientoDesde != null && filtros.filtroFechaNacimientoHasta != null) {
                DateTime fechaDesde = new DateTime(Convert.ToInt32(filtros.filtroFechaNacimientoDesde), 1, 1);
                DateTime fechaHasta = new DateTime(Convert.ToInt32(filtros.filtroFechaNacimientoHasta), 12, 31);
                listaCurriculums = listaCurriculums.Where(f => {
                    if (string.IsNullOrEmpty(f.FechaNacimiento.ToString())) return false;
                    var fechaF = Convert.ToDateTime(f.FechaNacimiento);
                    return (fechaF <= fechaHasta) && (fechaDesde <= fechaF);
                }).ToList();

            } else if (filtros.filtroFechaNacimientoDesde != null) {
                DateTime fechaDesde = new DateTime(Convert.ToInt32(filtros.filtroFechaNacimientoDesde), 1, 1);
                listaCurriculums = listaCurriculums.Where(f => {
                    if (string.IsNullOrEmpty(f.FechaNacimiento.ToString())) return false;
                    var fechaF = Convert.ToDateTime(f.FechaNacimiento);
                    return fechaDesde <= fechaF;
                }).ToList();

            } else if (filtros.filtroFechaNacimientoHasta != null) {
                DateTime fechaHasta = new DateTime(Convert.ToInt32(filtros.filtroFechaNacimientoHasta), 12, 31);
                listaCurriculums = listaCurriculums.Where(f => {
                    if (string.IsNullOrEmpty(f.FechaNacimiento.ToString())) return false;
                    var fechaF = Convert.ToDateTime(f.FechaNacimiento);
                    return fechaF <= fechaHasta;
                }).ToList();
            }
            if (filtros.filtroIdioma != null) {
                listaCurriculums = listaCurriculums.Where(fi => fi.Idioma.Contains(Convert.ToInt32(filtros.filtroIdioma))).ToList();
            }
            if (filtros.filtroNivelIdioma != null) {
                listaCurriculums = listaCurriculums.Where(fni => fni.NivelIdioma.Contains(Convert.ToInt32(filtros.filtroNivelIdioma))).ToList();
            }
            if (filtros.filtroTipoFormacion != null) {
                listaCurriculums = listaCurriculums.Where(ftf => ftf.TipoFormacion.Contains(Convert.ToInt32(filtros.filtroTipoFormacion))).ToList();
            }

            return listaCurriculums;
        }


        /**
         * Función para obtener las solicitudes de la vista de consultas de la base de datos.
         */
        public List<DatatableCurriculumAdminVM> ObtenerCurriculums() {

            List<DatatableCurriculumAdminVM> listaCurriculums = new List<DatatableCurriculumAdminVM>();

            List<Curriculum> lstCurriculums = _db.Curriculum.ToList();

            foreach(Curriculum curriculum in lstCurriculums) {
                UsuarioCV usuario = _db.UsuarioCV.Where(u => u.IdCurriculum == curriculum.IdCurriculum).FirstOrDefault();
                DatatableCurriculumAdminVM model = new DatatableCurriculumAdminVM() {
                    IdCurriculum = curriculum.IdCurriculum,
                    Titulo = curriculum.Titulo,
                    UltimaActualizacion = curriculum.FechaActualizacion != null ? curriculum.FechaActualizacion : curriculum.FechaCurriculum,
                    NombreCompleto = usuario.Nombre + " " + usuario.Apellido1 + " " + usuario.Apellido2,
                    Profesion = usuario.Profesion
                };
                listaCurriculums.Add(model);
            }

            return listaCurriculums;
        }
    }
}
