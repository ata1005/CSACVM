using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;
using CSACVM.Modelos;

namespace CSACVM.Controllers {
    public class LoginController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Login(LoginVM model) {
            try {
                var user = _unitOfWork.Usuario.ValidarUsuario(model);
                if (user == null) {
                    ModelState.AddModelError("password", "La contraseña es incorrecta o el usuario no existe");
                    return View(model);
                } else {
                    HttpContext.Session.SetString("NOMBRE", user.NombreUser);
                    HttpContext.Session.SetInt32("DPTO", user.IdDepartamento);
                    HttpContext.Session.SetInt32("ID", user.IdUsuario);
                    HttpContext.Session.SetString("ADMIN", user.Administrador.ToString());
                    if (user.Biografia != null) HttpContext.Session.SetString("BIO", user.Biografia.ToString());
                    if (user.IdGrupo != null) HttpContext.Session.SetInt32("GRUPO", Convert.ToInt32(user.IdGrupo));
                    if (user.IdRol != null) HttpContext.Session.SetInt32("ROL", Convert.ToInt32(user.IdRol));
                    return LocalRedirect("~/Home/Index");
                }
            } catch (Exception) {
                throw;
            }
        }


        public IActionResult Profile() {
            string username = HttpContext.Session.GetString("NOMBRE");
            string dpto = _unitOfWork.Departamento.GetFirstOrDefault(d => d.IdDepartamento == HttpContext.Session.GetInt32("DPTO")).Descripcion;
            Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.NombreUser == username);
            ProfileVM model = new ProfileVM {
                NombreUser = username,
                Dpto = dpto,
                Biografia = user.Biografia != null ? user.Biografia : "",
                ProfilePhoto = user.Foto != null ? user.Foto : ""
            };
            return View(model);
        }

        public IFormFile ImageFile { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarPerfil(ProfileVM model) {
            int idUser = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.IdUsuario == idUser);
            string folder = "CSACVM/wwwroot/ImagenPerfil";
            string absolutePath = System.IO.Path.GetFullPath(folder);
            string filename = "";
            string fullfilename = "";
            string ext = "";
            string ruta = "";
            string pathDirectorio = "";
            ImageFile = HttpContext.Request.Form.Files["fotoPerfil"];
            
            if (ImageFile != null) {
                ext = ImageFile.FileName.Split('.')[1];
                filename = "profilePhoto_" + idUser;
                fullfilename = filename + "." + ext;
                ruta = folder + "/" + fullfilename;
                pathDirectorio = absolutePath + "\\" + fullfilename;
                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }

                if (user.Foto != null) {
                    System.IO.File.Delete(pathDirectorio);
                } 

                using (FileStream fileStream = System.IO.File.Create(pathDirectorio)) {
                    await ImageFile.CopyToAsync(fileStream);
                   
                }

                _unitOfWork.Usuario.AddPhoto(user, ruta);
                
            }
         
            if (model.PassActual != null) {
                if (model.Password != null) {
                    if (model.ConfirmPassword != null) {
                        if (!_unitOfWork.Usuario.ComprobarPass(model.PassActual, model.NombreUser)) {
                            ModelState.AddModelError("passActual", "La contraseña es incorrecta para este usuario");
                            return View(model);
                        } else {
                            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                                try {
                                    _unitOfWork.Usuario.CambiarPass(model);
                                    dbTGuardar.Commit();
                                } catch (Exception ex) {
                                    dbTGuardar.Rollback();
                                    throw;
                                }
                            }    
                        }
                    } else {
                        ModelState.AddModelError("confirmPassword", "Se debe confirmar la nueva contraseña");
                        return View(model);
                    }
                } else {
                    ModelState.AddModelError("password", "Se debe rellenar el campo de la contraseña nueva");
                    ModelState.AddModelError("confirmPassword", "Se debe confirmar la nueva contraseña");
                    return View(model);
                }
            }
            if (model.ProfilePhoto != null || model.Biografia != null) {
                using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                    try {
                        _unitOfWork.Usuario.GuardarCambiosPerfil(model);
                        dbTGuardar.Commit();
                    } catch (Exception ex) {
                        dbTGuardar.Rollback();
                        throw;
                    }
                }
            }
            return LocalRedirect("~/Home/Index");
        }

    

        public async Task<IActionResult> LogoutAsync() {

            //Se limpian las variables de sesión
            HttpContext.Session.Remove("NOMBRE");
            HttpContext.Session.Remove("DPTO");
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("GRUPO");
            HttpContext.Session.Remove("ROL");
            HttpContext.Session.Remove("ADMIN");
            HttpContext.Session.Clear();

            //Si hace logout se redirige al Login para iniciar sesión con otro usuario.
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

            //Si se registra se redirige al Login para iniciar sesión.
            return LocalRedirect("~/Login/Login");
        }
    }
}