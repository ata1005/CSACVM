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
    public class EditarNotaController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public EditarNotaController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public IActionResult EditarNota(int idNota) {
            NotasVM model = new NotasVM() {
                IdNota = idNota,
                Nota = _unitOfWork.NotasUsuario.GetFirstOrDefault(n => n.IdNotaUsuario == idNota)
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GuardarNota(NotasVM model) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    _unitOfWork.NotasUsuario.GuardarNuevaNota(model, HttpContext.Session.GetInt32("ID").Value);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }

            return LocalRedirect("~/Directorio/Directorio");
        }
    }
}