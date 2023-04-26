using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;
using CSACVM.Modelos;

namespace CSACVM.Controllers {
    public class MantenimientoController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public MantenimientoController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult MantenimientoUsuario(){
            UsuarioAdminVM user = new() {
                ListaUsuarios = _unitOfWork.DatatableUsuarioAdminVM.ObtenerUsuarios(),
            };
            return View(user);
        }

        public JsonResult ObtenerUsuario(int idUsuario) {

            Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.IdUsuario == idUsuario);
            var x = new { nombreUser = user.NombreUser, nombre = user.Nombre, apellido = user.Apellido, idUser = idUsuario, activo = user.Activo, esAdmin = user.EsAdmin };
            return Json(x);
        }

        public void ActualizarUsuario(int idUsuario, string nombreUser, string nombre, string apellido, bool activo, bool esAdmin) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.IdUsuario == idUsuario);
                    _unitOfWork.Usuario.ActualizarUser(user, nombreUser, nombre, apellido, activo, esAdmin);
                    _unitOfWork.Save();

                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
        }
    }
}