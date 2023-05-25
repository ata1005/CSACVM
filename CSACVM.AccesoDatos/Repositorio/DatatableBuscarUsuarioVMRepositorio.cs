using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio {
    public class DatatableBuscarUsuarioVMRepositorio : Repositorio<DatatableBuscarUsuarioVM>, IDatatableBuscarUsuarioVMRepositorio {
        private readonly CSACVMContext _db;

        public DatatableBuscarUsuarioVMRepositorio(CSACVMContext db) : base(db) {
            _db = db;
        }

        public List<DatatableBuscarUsuarioVM> ObtenerUsuarios(List<Contacto> lstContactos, int idUsuario) {

            List<DatatableBuscarUsuarioVM> lstUsuarios = new List<DatatableBuscarUsuarioVM>();
            List<Usuario> lista = _db.Usuario.Where(us => us.IdUsuario != idUsuario).ToList();
            List<int> lstId = lstContactos.Select(c => c.IdUsuarioAgregado).ToList();
            foreach (Usuario user in lista) {
                string nombreUser = user.Nombre != null ? user.Nombre : "";
                string apellidoUser = user.Apellido != null ? user.Apellido : "";
                Departamento departamento = _db.Departamento.Where(d => d.IdDepartamento == user.IdDepartamento).FirstOrDefault();
                Rol rol = _db.Rol.Where(d => d.IdRol == user.IdRol).FirstOrDefault();

                if (!lstId.Contains(user.IdUsuario) && user.Activo) {
                    DatatableBuscarUsuarioVM model = new DatatableBuscarUsuarioVM() {
                        IdUsuario = user.IdUsuario,
                        Nombre = nombreUser + " " + apellidoUser,
                        Departamento = departamento != null ? departamento.Descripcion : "",
                        Rol = rol != null ? rol.Descripcion : "",
                        Foto = user.Foto != null ? user.Foto : "",
                        Email = user.Email != null ? user.Email : ""
                    };
                    lstUsuarios.Add(model);
                }
            }

            return lstUsuarios;
        }

        public List<DatatableBuscarUsuarioVM> ObtenerContactos(List<Contacto> lstContactos, int idUsuario) {

            List<DatatableBuscarUsuarioVM> lstUsuarios = new List<DatatableBuscarUsuarioVM>();
            List<Usuario> lista = _db.Usuario.Where(us => us.IdUsuario != idUsuario).ToList();
            List<int> lstId = lstContactos.Select(c => c.IdUsuarioAgregado).ToList();
            foreach (Usuario user in lista) {
                string nombreUser = user.Nombre != null ? user.Nombre : "";
                string apellidoUser = user.Apellido != null ? user.Apellido : "";
                Departamento departamento = _db.Departamento.Where(d => d.IdDepartamento == user.IdDepartamento).FirstOrDefault();
                Rol rol = _db.Rol.Where(d => d.IdRol == user.IdRol).FirstOrDefault();

                if (lstId.Contains(user.IdUsuario) && user.Activo) {
                    DatatableBuscarUsuarioVM model = new DatatableBuscarUsuarioVM() {
                        IdUsuario = user.IdUsuario,
                        Nombre = nombreUser + " " + apellidoUser,
                        Departamento = departamento != null ? departamento.Descripcion : "",
                        Rol = rol != null ? rol.Descripcion : "",
                        Foto = user.Foto != null ? user.Foto : "",
                        Email = user.Email != null ? user.Email : ""
                    };
                    lstUsuarios.Add(model);
                }
            }

            return lstUsuarios;
        }


    }
}
