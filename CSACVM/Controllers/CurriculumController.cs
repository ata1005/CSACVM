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
            int idUsuario = HttpContext.Session.GetInt32("ID").Value;
            CurriculumVM curriculum = new() {
                ListaCurriculums = _unitOfWork.Curriculum.ObtenerCurriculumsUsuario(idUsuario)
            };
            return View(curriculum);
        }

        public async Task<IActionResult> NuevoCurriculum(string titulo) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    _unitOfWork.Curriculum.GuardarNuevoCurriculum(titulo, HttpContext.Session.GetInt32("ID").Value);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
            return LocalRedirect("~/Curriculum");
        }

        public RedirectToActionResult RedirectCurriculum(int? idCurriculum) {
            return RedirectToAction("EditarCurriculum", "Curriculum", new { idCurriculum });
        }
        public IActionResult EditarCurriculum(int idCurriculum) {
            Curriculum curriculum = _unitOfWork.Curriculum.GetFirstOrDefault(c => c.IdCurriculum == idCurriculum);
            FotoUsuarioCV rutaFoto = _unitOfWork.FotoUsuarioCV.GetFirstOrDefault(f => f.IdCurriculum == idCurriculum);

            CurriculumModelVM model = new CurriculumModelVM() {
                IdCurriculum = idCurriculum,
                Titulo = curriculum.Titulo,
                Foto = rutaFoto != null ? rutaFoto.Ruta : "",
                ListaFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum)
            };
            return View("../Curriculum/EditarCurriculum", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarCurriculum(CurriculumModelVM model) {

            return LocalRedirect("~/Curriculum");
        }


    }
}