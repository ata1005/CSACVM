using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;

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

        public ActionResult NuevaEntrada(EntradaVM model)  {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {

                    int idUser = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
                    //Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.IdUsuario == idUser);
                    _unitOfWork.Entrada.NuevaEntrada(model, idUser);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }

            //Si se registra se redirige al Login para iniciar sesión.
            return LocalRedirect("~/Home/Index");
        }

        public ActionResult ObtenerEntradasFiltro(string filtroNombre, string filtroFechaDesde, string filtroFechaHasta, string filtroDescripcion) {

            DateTime fechaDesde = Convert.ToDateTime(filtroFechaDesde);
            DateTime fechaHasta = Convert.ToDateTime(filtroFechaHasta);
            List<ListaEntradaVM> lstEntradas = _unitOfWork.Entrada.ObtenerListaEntradaVM();

            if(filtroNombre != null) {
                lstEntradas = lstEntradas.Where(z => z.Usuario.NombreUser.Trim().ToUpper().Contains(filtroNombre.Trim().ToUpper())).ToList();
            }
            if (filtroFechaDesde != null && filtroFechaHasta != null) {
                lstEntradas = lstEntradas.Where(f => {
                    if (string.IsNullOrEmpty(f.Entrada.FechaCreacion.ToString())) return false;
                    var fechaF = Convert.ToDateTime(f.Entrada.FechaCreacion);
                    return (fechaF <= fechaHasta) && (fechaDesde <= fechaF);
                }).ToList();

            } else if (filtroFechaDesde != null) {
                lstEntradas = lstEntradas.Where(f => {
                    if (string.IsNullOrEmpty(f.Entrada.FechaCreacion.ToString())) return false;
                    var fechaF = Convert.ToDateTime(f.Entrada.FechaCreacion);
                    return fechaDesde <= fechaF;
                }).ToList();

            } else if (filtroFechaHasta != null) {
                lstEntradas = lstEntradas.Where(f => {
                    if (string.IsNullOrEmpty(f.Entrada.FechaCreacion.ToString())) return false;
                    var fechaF = Convert.ToDateTime(f.Entrada.FechaCreacion);
                    return fechaF <= fechaHasta;
                }).ToList();
            }
            if (filtroDescripcion != null) {
                lstEntradas = lstEntradas.Where(z2 => z2.Entrada.Descripcion.Trim().ToUpper().Contains(filtroDescripcion.Trim().ToUpper())).ToList();
            }

            string username = HttpContext.Session.GetString("NOMBRE");
            string foto = "";
            Usuario user = _unitOfWork.Usuario.GetFirstOrDefault(u => u.NombreUser == username);
            if (user != null) {
                if (user.Foto != null) foto = "/" + user.Foto.Split("/")[2] + "/" + user.Foto.Split("/")[3];
            }

            EntradaVM model = new EntradaVM() {
                NombreUser = username,
                RutaFoto = foto,
                ListaEntradaVM = lstEntradas
            };

            return View("Index",model);
        }
    }
}