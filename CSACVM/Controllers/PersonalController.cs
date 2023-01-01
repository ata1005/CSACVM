using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;

namespace CSACVM.Controllers {
    public class PersonalController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public PersonalController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Contactos()
        {
            return View();
        }
        public IActionResult Mensajes()
        {
            return View();
        }
        public IActionResult Notificaciones()
        {
            return View();
        }
        public IActionResult Directorio()
        {
            return View();
        }



    }
}