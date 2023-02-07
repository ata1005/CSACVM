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
    public class CurriculumController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public CurriculumController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Curriculum(){
            
            return View();
        }

        

    }
}