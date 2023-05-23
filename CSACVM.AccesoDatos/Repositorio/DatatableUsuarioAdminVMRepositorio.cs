using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio {
    public class DatatableUsuarioAdminVMRepositorio : Repositorio<DatatableUsuarioAdminVM>, IDatatableUsuarioAdminVMRepositorio {
        private readonly CSACVMContext _db;

        public DatatableUsuarioAdminVMRepositorio(CSACVMContext db) : base(db) {
            _db = db;
        }

        /**
         * Función para obtener las solicitudes de la vista de consultas de la base de datos.
         */
        public List<DatatableUsuarioAdminVM> ObtenerUsuarios() {

            List<DatatableUsuarioAdminVM> lstUsuarios = new List<DatatableUsuarioAdminVM>();

            List<Usuario> lista = _db.Usuario.ToList();

            foreach(Usuario user in lista) {

                DatatableUsuarioAdminVM model = new DatatableUsuarioAdminVM() {
                    IdUsuario = user.IdUsuario,
                    Activo = user.Activo,
                    EsAdmin = user.EsAdmin,
                    NombreUser = user.NombreUser,
                    Nombre = user.Nombre != null ? user.Nombre : "",
                    Apellido = user.Apellido != null ? user.Apellido : "",
                };
                lstUsuarios.Add(model);
            }

            return lstUsuarios;
        }

        public List<DatatableUsuarioAdminVM> ObtenerUsuarios(BusquedaFiltrosUsuario filtros) {
            List<DatatableUsuarioAdminVM> lstUsuarios = new List<DatatableUsuarioAdminVM>();

            List<Usuario> lista = _db.Usuario.ToList();

            foreach (Usuario user in lista) {

                DatatableUsuarioAdminVM model = new DatatableUsuarioAdminVM() {
                    IdUsuario = user.IdUsuario,
                    Activo = user.Activo,
                    EsAdmin = user.EsAdmin,
                    NombreUser = user.NombreUser,
                    Nombre = user.Nombre != null ? user.Nombre : "",
                    Apellido = user.Apellido != null ? user.Apellido : "",
                };
                lstUsuarios.Add(model);
            }

            

            if (filtros.filtroLogin != null) {
                lstUsuarios = lstUsuarios.Where(fL => fL.NombreUser.Trim().ToUpper().Contains(filtros.filtroLogin.Trim().ToUpper())).ToList();
            }
            if (filtros.filtroNombre != null) {
                lstUsuarios = lstUsuarios.Where(fN => fN.Nombre.Trim().ToUpper().Contains(filtros.filtroNombre.Trim().ToUpper())).ToList();
            }
            if (filtros.filtroApellido != null) {
                lstUsuarios = lstUsuarios.Where(fA => fA.Apellido.Trim().ToUpper().Contains(filtros.filtroApellido.Trim().ToUpper())).ToList();
            }

            if(filtros.filtroTodos == null) {
                if (filtros.filtroActivo != null) {
                    lstUsuarios = lstUsuarios.Where(fAc => fAc.Activo == filtros.filtroActivo).ToList();
                }
                if (filtros.filtroAdmin != null) {
                    lstUsuarios = lstUsuarios.Where(fAd => fAd.EsAdmin == filtros.filtroAdmin).ToList();
                }
            }
            return lstUsuarios;
        }
    }
}
