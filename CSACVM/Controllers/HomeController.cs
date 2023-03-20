using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSACVM.Controllers {
    public class HomeController : Controller {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Index() {
            string username = HttpContext.Session.GetString("NOMBRE");
            string foto = "";
            Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.NombreUser == username);
            if (user != null) {
                if(user.Foto != null) foto = "/" + user.Foto.Split("/")[2] + "/" + user.Foto.Split("/")[3];
            }
            EntradaVM model = new EntradaVM() {
                NombreUser = username,
                RutaFoto = foto,
                ListaEntradaVM = _unitOfWork.Entrada.ObtenerListaEntradaVM()
            };
            return View(model);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}