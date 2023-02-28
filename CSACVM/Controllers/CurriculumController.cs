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
            UsuarioCV usuarioCV = _unitOfWork.UsuarioCV.GetFirstOrDefault(u => u.IdCurriculum == idCurriculum);
            FormacionCV formacionCV = _unitOfWork.FormacionCV.GetFirstOrDefault(f2 => f2.IdCurriculum == idCurriculum);
            IdiomaCV idiomaCV = _unitOfWork.IdiomaCV.GetFirstOrDefault(i => i.IdCurriculum == idCurriculum);
            EntradaCV entradaCV = _unitOfWork.EntradaCV.GetFirstOrDefault(e => e.IdCurriculum == idCurriculum);
            ExtraCV extraCV = _unitOfWork.ExtraCV.GetFirstOrDefault(e2 => e2.IdCurriculum == idCurriculum);

            //Si los modelos son null, creamos una instancia de ese modelo con el idCurriculum.
            if (usuarioCV == null) _unitOfWork.UsuarioCV.NuevoUsuarioCV(HttpContext.Session.GetInt32("ID").Value, idCurriculum);
            

            CurriculumModelVM model = new CurriculumModelVM() {
                IdCurriculum = idCurriculum,
                Titulo = curriculum.Titulo,
                Foto = rutaFoto != null ? rutaFoto.Ruta : "",
                UsuarioCV = usuarioCV,
                FormacionCV = formacionCV,
                ListaFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum)
            };
            return View("../Curriculum/EditarCurriculum", model);
        }
        public IFormFile ImageFile { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarCurriculum(CurriculumModelVM model) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    int idUsuario = HttpContext.Session.GetInt32("ID").Value;
                    #region UsuarioCV.

                    //Zona de Imagen.
                    string folder = "wwwroot/ImagenPerfilCV";
                    string filename = "";
                    string ext = "";
                    string fullpath = "";
                    string pathDirectorio = "";
                    string guid = "";
                    ImageFile = HttpContext.Request.Form.Files["fotoCurriculum"];
                    FotoUsuarioCV fotoUsuarioCV = _unitOfWork.FotoUsuarioCV.GetFirstOrDefault(f => f.IdCurriculum == model.IdCurriculum);

                    if (ImageFile != null) {
                        ext = ImageFile.FileName.Split('.')[1];
                        filename = "profilePhoto_" + idUsuario + "_" + model.IdCurriculum + "." + ext;
                        fullpath = Path.Combine(folder, filename);
                        pathDirectorio = folder + "/" + filename;
                        guid = Guid.NewGuid().ToString();
                        if (!Directory.Exists(folder)) {
                            Directory.CreateDirectory(folder);
                        }

                        if (fotoUsuarioCV != null) {
                            System.IO.File.Delete(fotoUsuarioCV.Ruta);
                        }
                        
                        using (FileStream fileStream = System.IO.File.Create(fullpath)) {
                            await ImageFile.CopyToAsync(fileStream);

                        }
                        if (fotoUsuarioCV != null) {
                            _unitOfWork.FotoUsuarioCV.ChangePhoto(fotoUsuarioCV, pathDirectorio, guid, ext, idUsuario);
                        } else {
                            _unitOfWork.FotoUsuarioCV.AddPhoto(pathDirectorio, guid, ext, idUsuario, model.IdCurriculum);
                        }

                    }

                    //Zona de guardado de UsuarioCV.

                    UsuarioCV usuarioCV = _unitOfWork.UsuarioCV.GetFirstOrDefault(a => a.IdCurriculum == model.IdCurriculum);   
                    _unitOfWork.UsuarioCV.GuardarUsuarioCV(usuarioCV,model,idUsuario,fotoUsuarioCV);
                     

                    #endregion

                    #region FormacionCV.


                    #endregion

                    #region IdiomaCV.


                    #endregion

                    #region EntradaCV.


                    #endregion

                    #region ExtraCV.


                    #endregion

                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }

            return LocalRedirect("~/Curriculum/Curriculum");
        }


    }
}