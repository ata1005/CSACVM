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

        public RedirectToActionResult EditarNota(int? idNota) {
            return RedirectToAction("EditarNota", "EditarNota", new { idNota });
        }

        [HttpGet]
        public async Task<IActionResult> EliminarNota(int idNota) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    _unitOfWork.NotasUsuario.EliminarNota(idNota);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
            return LocalRedirect("~/Home/Home");
        }

        public IActionResult Notas() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NuevaNota(NotasVM model) {
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