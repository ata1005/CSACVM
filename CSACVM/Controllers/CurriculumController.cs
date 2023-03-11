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


            //Si los modelos son null, creamos una instancia de ese modelo con el idCurriculum.
            if (usuarioCV == null) _unitOfWork.UsuarioCV.NuevoUsuarioCV(HttpContext.Session.GetInt32("ID").Value, idCurriculum);
            

            CurriculumModelVM model = new CurriculumModelVM() {
                IdCurriculum = idCurriculum,
                Titulo = curriculum.Titulo,
                Foto = rutaFoto != null ? rutaFoto.Ruta : "",
                UsuarioCV = usuarioCV,
                ListaFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum),
                ListaIdiomaCV = _unitOfWork.IdiomaCV.ObtenerListaIdioma(idCurriculum),
                ListaEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(idCurriculum),
                ListaAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(idCurriculum),
                ListaLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(idCurriculum)
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
                    _unitOfWork.UsuarioCV.GuardarUsuarioCV(usuarioCV, model, idUsuario, fotoUsuarioCV);


                    #endregion

                    #region FormacionCV.
                    List<FormacionCV> lstFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(model.IdCurriculum);
                    List<string> lstGradoFormacion = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstObservacionesFormacion = new List<string>();//Request.Form["observacionesFormacion"].ToList();                  
                    List<string> lstUbicacionFormacion = new List<string>();//Request.Form["ubicacionFormacion"].ToList();
                    List<string> lstDateDesdeFormacion = new List<string>(); //Request.Form["fechaDesdeFormacion"].ToList();
                    List<string> lstDateHastaFormacion = new List<string>(); //Request.Form["fechaHastaFormacion"].ToList();

                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("gradoFormacion_"))) {
                        if (Request.Form[element] != "") lstGradoFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("ubicacionFormacion_"))) {
                        if (Request.Form[element] != "") lstUbicacionFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("observacionesFormacion_"))) {
                        if (Request.Form[element] != "") lstObservacionesFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaDesdeFormacion_"))) {
                        if (Request.Form[element] != "") lstDateDesdeFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaHastaFormacion_"))) {
                        if (Request.Form[element] != "") lstDateHastaFormacion.Add(Request.Form[element]);
                    }

                    if (lstGradoFormacion.Count > 0) _unitOfWork.FormacionCV.GuardarFormacion(lstFormacionCV, lstGradoFormacion,lstUbicacionFormacion, lstObservacionesFormacion, lstDateDesdeFormacion, lstDateHastaFormacion, model.IdCurriculum, idUsuario);
                    #endregion

                    #region IdiomaCV.
                    List<IdiomaCV> lstIdiomaCV = _unitOfWork.IdiomaCV.ObtenerListaIdioma(model.IdCurriculum);
                    List<string> lstDescripcionIdioma = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstNivelIdioma = new List<string>();//Request.Form["observacionesFormacion"].ToList();                  
                    List<string> lstCentroIdioma = new List<string>();//Request.Form["ubicacionFormacion"].ToList();
                    List<string> lstDateDesdeIdioma = new List<string>(); //Request.Form["fechaDesdeFormacion"].ToList();
                    List<string> lstDateHastaIdioma = new List<string>(); //Request.Form["fechaHastaFormacion"].ToList();

                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("descripcionIdioma_"))) {
                        if (Request.Form[element] != "") lstDescripcionIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("nivelIdioma_"))) {
                        if (Request.Form[element] != "") lstNivelIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("centroIdioma_"))) {
                        if (Request.Form[element] != "") lstCentroIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaDesdeIdioma_"))) {
                        if (Request.Form[element] != "") lstDateDesdeIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaHastaIdioma_"))) {
                        if (Request.Form[element] != "") lstDateHastaIdioma.Add(Request.Form[element]);
                    }

                    if(lstDescripcionIdioma.Count > 0) _unitOfWork.IdiomaCV.GuardarIdioma(lstIdiomaCV, lstDescripcionIdioma, lstNivelIdioma, lstCentroIdioma, lstDateDesdeIdioma, lstDateHastaIdioma, model.IdCurriculum, idUsuario);

                    #endregion

                    #region EntradaCV.
                    List<EntradaCV> lstEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(model.IdCurriculum);
                    List<string> lstPuestoTrabajo = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstEmpresaAsociada = new List<string>();//Request.Form["observacionesFormacion"].ToList();
                    List<string> lstUbicacionEntrada= new List<string>();//Request.Form["ubicacionFormacion"].ToList();
                    List<string> lstObservacionesEntrada = new List<string>();
                    List<string> lstDateDesdeEntrada = new List<string>(); //Request.Form["fechaDesdeFormacion"].ToList();
                    List<string> lstDateHastaEntrada = new List<string>(); //Request.Form["fechaHastaFormacion"].ToList();

                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("puestoTrabajo_"))) {
                        if (Request.Form[element] != "") lstPuestoTrabajo.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("empresaAsociada_"))) {
                        if (Request.Form[element] != "") lstEmpresaAsociada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("ubicacionEntrada_"))) {
                        if (Request.Form[element] != "") lstUbicacionEntrada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("observacionesEntrada_"))) {
                        if (Request.Form[element] != "") lstObservacionesEntrada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaDesdeEntrada_"))) {
                        if (Request.Form[element] != "") lstDateDesdeEntrada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaHastaEntrada_"))) {
                        if (Request.Form[element] != "") lstDateHastaEntrada.Add(Request.Form[element]);
                    }

                    if (lstPuestoTrabajo.Count > 0) _unitOfWork.EntradaCV.GuardarEntrada(lstEntradaCV, lstPuestoTrabajo, lstEmpresaAsociada, lstUbicacionEntrada, lstObservacionesEntrada, lstDateDesdeEntrada, lstDateHastaEntrada, model.IdCurriculum, idUsuario);


                    #endregion

                    #region Extras: AptitudCV y LogroCV.
                    List<AptitudCV> lstAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(model.IdCurriculum);
                    List<LogroCV> lstLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(model.IdCurriculum);
                    List<string> lstDescripcionAptitud = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstDescripcionLogro = new List<string>();//Request.Form["observacionesFormacion"].ToList();
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("aptitud_"))) {
                        if (Request.Form[element] != "") lstDescripcionAptitud.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("logro_"))) {
                        if (Request.Form[element] != "") lstDescripcionLogro.Add(Request.Form[element]);
                    }
                    if (lstAptitudCV.Count > 0) _unitOfWork.AptitudCV.GuardarAptitud(lstAptitudCV, lstDescripcionAptitud, model.IdCurriculum, idUsuario);
                    if (lstDescripcionLogro.Count > 0) _unitOfWork.LogroCV.GuardarLogro(lstLogroCV, lstDescripcionLogro,  model.IdCurriculum, idUsuario);

                    #endregion

                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }

            return LocalRedirect("~/Curriculum/Curriculum");
        }

        public ActionResult EliminarCurriculum(int idCurriculum) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    //Obtención de los datos.
                    Curriculum curriculum = _unitOfWork.Curriculum.GetFirstOrDefault(c => c.IdCurriculum == idCurriculum);               
                    UsuarioCV usuarioCV = _unitOfWork.UsuarioCV.GetFirstOrDefault(u => u.IdCurriculum == idCurriculum);
                    FotoUsuarioCV fotoUsuarioCV = _unitOfWork.FotoUsuarioCV.GetFirstOrDefault(f => f.IdCurriculum == idCurriculum);
                    List<FormacionCV> lstFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum);
                    List<IdiomaCV> lstIdiomaCV = _unitOfWork.IdiomaCV.ObtenerListaIdioma(idCurriculum);
                    List<EntradaCV> lstEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(idCurriculum);
                    List<AptitudCV> lstAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(idCurriculum);
                    List<LogroCV> lstLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(idCurriculum);

                    //Eliminar instancia de UsuarioCV + Foto.
                    if (usuarioCV != null) {
                        _unitOfWork.UsuarioCV.EliminarUsuario(usuarioCV);
                        if (fotoUsuarioCV != null) {
                            _unitOfWork.FotoUsuarioCV.EliminarFotoUsuario(fotoUsuarioCV);
                        }
                    }

                    //Eliminar instancia de FormaciónCV.
                    foreach(FormacionCV formacion in lstFormacionCV) {
                        _unitOfWork.FormacionCV.EliminarFormacion(formacion);
                    }

                    //Eliminar instancia de IdiomaCV.
                    foreach (IdiomaCV idioma in lstIdiomaCV) {
                        _unitOfWork.IdiomaCV.EliminarIdioma(idioma);
                    }

                    //Eliminar instancia de EntradaCV.
                    foreach (EntradaCV entrada in lstEntradaCV) {
                        _unitOfWork.EntradaCV.EliminarEntrada(entrada);
                    }

                    //Eliminar instancia de LogroCV + AptitudCV.
                    foreach (AptitudCV aptitud in lstAptitudCV) {
                        _unitOfWork.AptitudCV.EliminarAptitud(aptitud);
                    }
                    foreach (LogroCV logro in lstLogroCV) {
                        _unitOfWork.LogroCV.EliminarLogro(logro);
                    }

                    //Eliminar de la tabla currículums.
                    if (curriculum != null) {
                        _unitOfWork.Curriculum.EliminarCurriculum(curriculum);
                    }

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