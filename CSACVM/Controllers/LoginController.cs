using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;
using Microsoft.AspNetCore.Http;

namespace CSACVM.Controllers {
    public class LoginController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Login() {
            return View();
        }


        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Login(LoginVM model) {
            try {
                var user = _unitOfWork.Usuario.ValidarUsuario(model);
                if (user == null){
                    ModelState.AddModelError("password", "La contraseña es incorrecta o el usuario no existe");
                    return View(model);
                } else {
                    HttpContext.Session.SetString("NOMBRE", user.NombreUser);
                    HttpContext.Session.SetInt32("DPTO", user.IdDepartamento);
                    HttpContext.Session.SetInt32("ID", user.IdUsuario);
                    HttpContext.Session.SetString("ADMIN", user.Administrador.ToString());
                    if(user.IdGrupo != null) HttpContext.Session.SetInt32("GRUPO", Convert.ToInt32(user.IdGrupo));
                    if(user.IdRol != null) HttpContext.Session.SetInt32("ROL", Convert.ToInt32(user.IdRol));
                    return LocalRedirect("~/Home/Index");
                }
            } catch (Exception) {
                throw;
            }

        }

        public async Task<IActionResult> LogoutAsync() {
            HttpContext.Session.Remove("NOMBRE");
            HttpContext.Session.Remove("DPTO");
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("GRUPO");
            HttpContext.Session.Remove("ROL");
            HttpContext.Session.Remove("ADMIN");
            HttpContext.Session.Clear();
            // Si hace logout se redirige al Login para iniciar sesión con otro usuario.
            return RedirectPermanent("~/Login/Login");
        }

        public IActionResult Register() {
            RegisterVM model = new() {
                ListaDepartamentos = _unitOfWork.Departamento.ObtenerDepartamentos(),
                ListaGrupos = _unitOfWork.Grupo.ObtenerGrupos(),
                ListaRoles = _unitOfWork.Rol.ObtenerRoles()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model) {

            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    var user = _unitOfWork.Usuario.Register(model);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
            //var user = _unitOfWork.Usuario.Register(model);
            // Si se registra se redirige al Login para iniciar sesión.
            return LocalRedirect("~/Login/Login");
        }
    }
}