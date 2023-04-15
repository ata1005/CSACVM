using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using Newtonsoft.Json;
using CSACVM.AccesoDatos.Repositorio;
using CSACVM.Modelos;
using Rotativa.AspNetCore.Options;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System;
using CSACVM.AccesoDatos;

namespace CSACVM.Controllers {
    public class CurriculumController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public CurriculumController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult CurriculumIndex() {
            int idUsuario = HttpContext.Session.GetInt32("ID").Value;
            Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.IdUsuario == idUsuario);
            if (user.EsAdmin) {
                return RedirectToAction("CurriculumAdmin");
            } else {
                return RedirectToAction("Curriculum", new { id = idUsuario });
            }
        }

        public ActionResult Curriculum(int id) {
            CurriculumVM curriculum = new() {
                ListaCurriculums = _unitOfWork.Curriculum.ObtenerCurriculumsUsuario(id)
            };
            return View(curriculum);
        }
        public ActionResult CurriculumAdmin() {
            CurriculumAdminVM curriculum = new() {
                ListaCurriculums = _unitOfWork.DatatableCurriculumAdminVM.ObtenerCurriculums(),
                ListaIdioma = _unitOfWork.Idioma.ObtenerIdiomas(),
                ListaTipoFormacion = _unitOfWork.TipoFormacion.ObtenerTipoFormacion(),
                ListaNivelIdioma = _unitOfWork.NivelIdioma.ObtenerNivelIdioma()
            };
            return View(curriculum);
        }
        public JsonResult ObtenerCurriculumsFiltro(BusquedaFiltros filtros) {
            List<DatatableCurriculumAdminVM> curriculums = _unitOfWork.DatatableCurriculumAdminVM.ObtenerCurriculums(filtros);
            return Json(curriculums);
        }

        public JsonResult ObtenerDatosModalVer(int idCurriculum) {
            UsuarioCV user = _unitOfWork.UsuarioCV.GetFirstOrDefault(u => u.IdCurriculum== idCurriculum);
            string nombre = user.Nombre + " " + user.Apellido1 + " " + user.Apellido2;
            var datos = new {nombreCompleto = nombre, nacionalidad = user.Nacionalidad, fechaNac = Convert.ToDateTime(user.FechaNacimiento).ToShortDateString().ToString(),
                                profesion = user.Profesion, telefono = user.Telefono, email = user.Email, acercaDe =user.AcercaDe};

            return Json(datos);
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
                Foto = rutaFoto != null ? rutaFoto.Ruta + "." + rutaFoto.Ext : "",
                UsuarioCV = usuarioCV,
                ListaFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum),
                ListaIdiomaCV = _unitOfWork.IdiomaCV.ObtenerListaIdioma(idCurriculum),
                ListaEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(idCurriculum),
                ListaAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(idCurriculum),
                ListaLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(idCurriculum),
                ListaIdiomas = _unitOfWork.Idioma.ObtenerIdiomas(),
                ListaTipoFormacion = _unitOfWork.TipoFormacion.ObtenerTipoFormacion(),
                ListaNivelIdiomas = _unitOfWork.NivelIdioma.ObtenerNivelIdioma()
            };
            return View("../Curriculum/EditarCurriculum", model);
        }

        public ActionResult ExportarPDF(int idCurriculum) {
            Curriculum curriculum = _unitOfWork.Curriculum.GetFirstOrDefault(c => c.IdCurriculum == idCurriculum);
            FotoUsuarioCV rutaFoto = _unitOfWork.FotoUsuarioCV.GetFirstOrDefault(f => f.IdCurriculum == idCurriculum);
            UsuarioCV usuarioCV = _unitOfWork.UsuarioCV.GetFirstOrDefault(u => u.IdCurriculum == idCurriculum);
            Dictionary<string, string> idiomaDict = new Dictionary<string, string>();
            List<IdiomaCV> ListaIdiomas = _unitOfWork.IdiomaCV.ObtenerListaIdioma(idCurriculum);

            foreach(IdiomaCV idioma in ListaIdiomas) {
                string descripcion = _unitOfWork.Idioma.GetFirstOrDefault(i => i.IdIdioma == idioma.IdIdioma).Descripcion;
                string nivel = _unitOfWork.NivelIdioma.GetFirstOrDefault(n => n.idNivelIdioma == idioma.IdNivelIdioma).Descripcion;
                idiomaDict.Add(descripcion, nivel);
            }

            CurriculumModelVM model = new CurriculumModelVM() {
                IdCurriculum = idCurriculum,
                Titulo = curriculum.Titulo,
                Foto = rutaFoto != null ? rutaFoto.Ruta + "." + rutaFoto.Ext : "",
                UsuarioCV = usuarioCV,
                ListaFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum),
                ListaIdiomaCV = ListaIdiomas,
                DictIdiomasCV = idiomaDict,
                ListaEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(idCurriculum),
                ListaAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(idCurriculum),
                ListaLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(idCurriculum)
            };

            return new Rotativa.AspNetCore.ViewAsPdf("_ExportarPDF_2", model) {
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                PageMargins = { Left = 5, Right = 3, Bottom = 5 },
                CustomSwitches = "--footer-center \" " + "P\u00E1gina" + ": [page]/[toPage]\"" + " --footer-line --footer-font-size \"8\" --footer-spacing 1 --footer-font-name \"Meridien\" --print-media-type"
            };
        }

        public async Task<ActionResult> ClonarCurriculumAsync(int idCurriculum) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    int idUsuario = HttpContext.Session.GetInt32("ID").Value;
                    Curriculum curriculum = _unitOfWork.Curriculum.GetFirstOrDefault(c => c.IdCurriculum == idCurriculum);
                    FotoUsuarioCV rutaFoto = _unitOfWork.FotoUsuarioCV.GetFirstOrDefault(f => f.IdCurriculum == idCurriculum);
                    UsuarioCV usuarioCV = _unitOfWork.UsuarioCV.GetFirstOrDefault(u => u.IdCurriculum == idCurriculum);
                    CurriculumModelVM model = new CurriculumModelVM() {
                        IdCurriculum = idCurriculum,
                        Titulo = curriculum.Titulo,
                        Foto = rutaFoto != null ? rutaFoto.Ruta + "." + rutaFoto.Ext : "",
                        UsuarioCV = usuarioCV,
                        ListaFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(idCurriculum),
                        ListaIdiomaCV = _unitOfWork.IdiomaCV.ObtenerListaIdioma(idCurriculum),
                        ListaEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(idCurriculum),
                        ListaAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(idCurriculum),
                        ListaLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(idCurriculum)
                    };

                    Curriculum clonado = new() {
                        IdUsuario = idUsuario,
                        Titulo = curriculum.Titulo + "_CPY",
                        FechaCurriculum = DateTime.Now,
                        FechaCreacion = DateTime.Now,
                        ProcesoCreacion = MethodBase.GetCurrentMethod().Name
                    };

                    _unitOfWork.Curriculum.Add(clonado);
                    model.IdCurriculum = clonado.IdCurriculum;
                    _unitOfWork.Save();
                    model.IdCurriculum = clonado.IdCurriculum;

                    //string folder = "CSACVM/wwwroot/ImagenPerfilCV";
                    //string absolutePath = System.IO.Path.GetFullPath(folder);
                    //string filename = "";
                    //string fullfilename = "";
                    //string ext = "";
                    //string ruta = "";
                    //string pathDirectorio = "";
                    //string guid = "";

                    //if (rutaFoto != null) {
                    //    ext = model.Foto.Split('.')[1];
                    //    filename = "profilePhoto_" + idUsuario + "_" + clonado.IdCurriculum;
                    //    fullfilename = filename + "." + ext;
                    //    ruta = folder + "/" + filename;
                    //    pathDirectorio = absolutePath + "\\" + fullfilename;
                    //    guid = Guid.NewGuid().ToString();
                    //    if (!Directory.Exists(folder)) {
                    //        Directory.CreateDirectory(folder);
                    //    }

                    //    using (FileStream fileStream = System.IO.File.Create(pathDirectorio)) {
                    //        await ImageFile.CopyToAsync(fileStream);
                    //    }
                    //    _unitOfWork.FotoUsuarioCV.AddPhoto(ruta, guid, ext, idUsuario, clonado.IdCurriculum);
                    //}
                    
                    _unitOfWork.UsuarioCV.ClonadoUsuarioCV(clonado, model);
                    _unitOfWork.FormacionCV.ClonadoFormacionCV(clonado, model);
                    _unitOfWork.EntradaCV.ClonadoEntradaCV(clonado, model);
                    _unitOfWork.IdiomaCV.ClonadoIdiomaCV(clonado, model);
                    _unitOfWork.LogroCV.ClonadoLogroCV(clonado, model);
                    _unitOfWork.AptitudCV.ClonadoAptitudCV(clonado, model);

                    _unitOfWork.Save();
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
            return LocalRedirect("~/Curriculum/Curriculum");
        }
        public IFormFile ImageFile { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarCurriculumAsync(CurriculumModelVM model) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    Curriculum curriculum = _unitOfWork.Curriculum.GetFirstOrDefault(c => c.IdCurriculum == model.IdCurriculum);
                    _unitOfWork.Curriculum.ActualizarNombre(curriculum, model);

                    int idUsuario = HttpContext.Session.GetInt32("ID").Value;
                    #region UsuarioCV.

                    //Zona de Imagen.
                    //string illo = "C:\\Users\\alext\\Desktop\\TFG\\TFG\\Repositorio\\CSACVM\\CSACVM\\wwwroot\\ImagenPerfilCV";
                    string folder = "CSACVM/wwwroot/ImagenPerfilCV";
                    string absolutePath = System.IO.Path.GetFullPath(folder);
                    string filename = "";
                    string fullfilename = "";
                    string ext = "";
                    string ruta = "";
                    string pathDirectorio = "";
                    string guid = "";
                    ImageFile = HttpContext.Request.Form.Files["fotoCurriculum"];
                    FotoUsuarioCV fotoUsuarioCV = _unitOfWork.FotoUsuarioCV.GetFirstOrDefault(f => f.IdCurriculum == model.IdCurriculum);

                    if (ImageFile != null) {
                        ext = ImageFile.FileName.Split('.')[1];
                        filename = "profilePhoto_" + idUsuario + "_" + model.IdCurriculum;
                        fullfilename = filename + "." + ext;
                        ruta = folder + "/" + filename;
                        pathDirectorio = absolutePath + "\\" + fullfilename;
                        guid = Guid.NewGuid().ToString();
                        if (!Directory.Exists(folder)) {
                            Directory.CreateDirectory(folder);
                        }

                        if (fotoUsuarioCV != null) {
                            System.IO.File.Delete(pathDirectorio);
                        }

                        using (FileStream fileStream = System.IO.File.Create(pathDirectorio)) {
                            await ImageFile.CopyToAsync(fileStream);

                        }
                        if (fotoUsuarioCV != null) {
                            _unitOfWork.FotoUsuarioCV.ChangePhoto(fotoUsuarioCV, ruta, guid, ext, idUsuario);
                        } else {
                            _unitOfWork.FotoUsuarioCV.AddPhoto(ruta, guid, ext, idUsuario, model.IdCurriculum);
                        }

                    }

                    //Zona de guardado de UsuarioCV.

                    UsuarioCV usuarioCV = _unitOfWork.UsuarioCV.GetFirstOrDefault(a => a.IdCurriculum == model.IdCurriculum);
                    _unitOfWork.UsuarioCV.GuardarUsuarioCV(usuarioCV, model, idUsuario, fotoUsuarioCV);


                    #endregion

                    #region FormacionCV.
                    List<FormacionCV> lstFormacionCV = _unitOfWork.FormacionCV.ObtenerListaFormacion(model.IdCurriculum);
                    List<string> lstTipoFormacion = new List<string>();
                    List<string> lstGradoFormacion = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstObservacionesFormacion = new List<string>();//Request.Form["observacionesFormacion"].ToList();                  
                    List<string> lstUbicacionFormacion = new List<string>();//Request.Form["ubicacionFormacion"].ToList();
                    List<string> lstDateDesdeFormacion = new List<string>(); //Request.Form["fechaDesdeFormacion"].ToList();
                    List<string> lstDateHastaFormacion = new List<string>(); //Request.Form["fechaHastaFormacion"].ToList();

                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("idTipoFormacion_"))) {
                        lstTipoFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("gradoFormacion_"))) {
                        lstGradoFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("ubicacionFormacion_"))) {
                        lstUbicacionFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("observacionesFormacion_"))) {
                        lstObservacionesFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaDesdeFormacion_"))) {
                        lstDateDesdeFormacion.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaHastaFormacion_"))) {
                        lstDateHastaFormacion.Add(Request.Form[element]);
                    }

                    int vacioFormacion = 0;
                    foreach (string formacion in lstGradoFormacion) {
                        if (formacion != "") vacioFormacion++;
                    }
                    if (vacioFormacion > 0) _unitOfWork.FormacionCV.GuardarFormacion(lstFormacionCV,lstTipoFormacion, lstGradoFormacion, lstUbicacionFormacion, lstObservacionesFormacion, lstDateDesdeFormacion, lstDateHastaFormacion, model.IdCurriculum, idUsuario);
                    #endregion

                    #region IdiomaCV.
                    List<IdiomaCV> lstIdiomaCV = _unitOfWork.IdiomaCV.ObtenerListaIdioma(model.IdCurriculum);
                    List<string> lstIdioma = new List<string>();
                    List<string> lstDescripcionIdioma = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstNivelIdioma = new List<string>();//Request.Form["observacionesFormacion"].ToList();                  
                    List<string> lstCentroIdioma = new List<string>();//Request.Form["ubicacionFormacion"].ToList();
                    List<string> lstDateDesdeIdioma = new List<string>(); //Request.Form["fechaDesdeFormacion"].ToList();
                    List<string> lstDateHastaIdioma = new List<string>(); //Request.Form["fechaHastaFormacion"].ToList();

                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("idIdioma_"))) {
                        lstIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("descripcionIdioma_"))) {
                        lstDescripcionIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("idNivelIdioma_"))) {
                        lstNivelIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("centroIdioma_"))) {
                        lstCentroIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaDesdeIdioma_"))) {
                        lstDateDesdeIdioma.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaHastaIdioma_"))) {
                        lstDateHastaIdioma.Add(Request.Form[element]);
                    }

                    int vacioIdioma = 0;
                    foreach (string idioma in lstDescripcionIdioma) {
                        if (idioma != "") vacioIdioma++;
                    }
                    if (vacioIdioma > 0) _unitOfWork.IdiomaCV.GuardarIdioma(lstIdiomaCV,lstIdioma, lstDescripcionIdioma, lstNivelIdioma, lstCentroIdioma, lstDateDesdeIdioma, lstDateHastaIdioma, model.IdCurriculum, idUsuario);

                    #endregion

                    #region EntradaCV.
                    List<EntradaCV> lstEntradaCV = _unitOfWork.EntradaCV.ObtenerListaEntrada(model.IdCurriculum);
                    List<string> lstPuestoTrabajo = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstEmpresaAsociada = new List<string>();//Request.Form["observacionesFormacion"].ToList();
                    List<string> lstUbicacionEntrada = new List<string>();//Request.Form["ubicacionFormacion"].ToList();
                    List<string> lstObservacionesEntrada = new List<string>();
                    List<string> lstDateDesdeEntrada = new List<string>(); //Request.Form["fechaDesdeFormacion"].ToList();
                    List<string> lstDateHastaEntrada = new List<string>(); //Request.Form["fechaHastaFormacion"].ToList();

                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("puestoTrabajo_"))) {
                        lstPuestoTrabajo.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("empresaAsociada_"))) {
                        lstEmpresaAsociada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("ubicacionEntrada_"))) {
                        lstUbicacionEntrada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("observacionesEntrada_"))) {
                        lstObservacionesEntrada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaDesdeEntrada_"))) {
                        lstDateDesdeEntrada.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("fechaHastaEntrada_"))) {
                        lstDateHastaEntrada.Add(Request.Form[element]);
                    }

                    int vacioEntrada = 0;
                    foreach (string puesto in lstPuestoTrabajo) {
                        if (puesto != "") vacioEntrada++;
                    }
                    if (vacioEntrada > 0) _unitOfWork.EntradaCV.GuardarEntrada(lstEntradaCV, lstPuestoTrabajo, lstEmpresaAsociada, lstUbicacionEntrada, lstObservacionesEntrada, lstDateDesdeEntrada, lstDateHastaEntrada, model.IdCurriculum, idUsuario);


                    #endregion

                    #region Extras: AptitudCV y LogroCV.
                    List<AptitudCV> lstAptitudCV = _unitOfWork.AptitudCV.ObtenerListaAptitud(model.IdCurriculum);
                    List<LogroCV> lstLogroCV = _unitOfWork.LogroCV.ObtenerListaLogro(model.IdCurriculum);
                    List<string> lstDescripcionAptitud = new List<string>(); //Request.Form["gradoFormacion"].ToList();
                    List<string> lstDescripcionLogro = new List<string>();//Request.Form["observacionesFormacion"].ToList();
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("aptitud_"))) {
                        lstDescripcionAptitud.Add(Request.Form[element]);
                    }
                    foreach (string element in Request.Form.Keys.Where(x => x.StartsWith("logro_"))) {
                        lstDescripcionLogro.Add(Request.Form[element]);
                    }

                    int vacioAptitud = 0;
                    int vacioLogro = 0;
                    foreach (string actitud in lstDescripcionAptitud) {
                        if (actitud != "") vacioAptitud++;
                    }
                    foreach (string logro in lstDescripcionLogro) {
                        if (logro != "") vacioLogro++;
                    }
                    if (vacioAptitud > 0) _unitOfWork.AptitudCV.GuardarAptitud(lstAptitudCV, lstDescripcionAptitud, model.IdCurriculum, idUsuario);
                    if (vacioLogro > 0) _unitOfWork.LogroCV.GuardarLogro(lstLogroCV, lstDescripcionLogro, model.IdCurriculum, idUsuario);

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
                    foreach (FormacionCV formacion in lstFormacionCV) {
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