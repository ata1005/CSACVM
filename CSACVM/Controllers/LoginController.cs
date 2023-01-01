using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;

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
        public async Task<IActionResult> Login(LoginVM model) {

            try {
                //var user = unitOfWork.UserRepository.Validate(model);
                //if (user == null) {
                //    ModelState.AddModelError("password", "La contraseña es incorrecta o el usuario no existe");
                //    return View(model);
                //}
                //await unitOfWork.UserManager.SignIn(this.HttpContext, user, false);
                return LocalRedirect("~/Solicitudes/Solicitudes");

            } catch (Exception) {
                throw;
            }

        }

        public async Task<IActionResult> LogoutAsync() {
            //await unitOfWork.UserManager.SignOut(this.HttpContext);

            // Si hace logout se redirige al Login para iniciar sesión con otro usuario.
            return RedirectPermanent("~/Login/Login");
        }
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model) {


            //var user = unitOfWork.UserRepository.Register(model);

            //await unitOfWork.UserManager.SignIn(this.HttpContext, user, false);

            // Si se registra se redirige al Login para iniciar sesión.
            return LocalRedirect("~/Login/Login");
        }
    }
}