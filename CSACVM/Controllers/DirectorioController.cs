using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;

namespace CSACVM.Controllers {
    public class DirectorioController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public DirectorioController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Directorio(){
            int idUsuario = HttpContext.Session.GetInt32("ID").Value;
            DirectorioVM directorio = new() {
                ListaNotas = _unitOfWork.NotasUsuario.ObtenerNotasUsuario(idUsuario)
               
            };
            return View(directorio);
        }



    }
}