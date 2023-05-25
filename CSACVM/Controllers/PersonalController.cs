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
    public class PersonalController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public PersonalController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IActionResult Contactos(){
            int idUsuario = HttpContext.Session.GetInt32("ID").Value;
            List<Contacto> listaCont = _unitOfWork.Contacto.ObtenerContactosUsuario(idUsuario);
            ContactoVM model = new ContactoVM() {
                ListaContactos = _unitOfWork.DatatableBuscarUsuarioVM.ObtenerContactos(listaCont, idUsuario),
                ListaUsuarios = _unitOfWork.DatatableBuscarUsuarioVM.ObtenerUsuarios(listaCont, idUsuario)
            };
            return View(model);
        }

        public async Task<IActionResult> AnadirContacto(int idUsuario) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    int idUser = HttpContext.Session.GetInt32("ID").Value;
                    _unitOfWork.Contacto.GuardarContacto(idUser, idUsuario);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
            return LocalRedirect("~/Personal/Contactos");
        }

        public async Task<IActionResult> EliminarContacto(int idUsuario) {
            using (var dbTGuardar = _unitOfWork.GetContext().Database.BeginTransaction()) {
                try {
                    int idUser = HttpContext.Session.GetInt32("ID").Value;
                    _unitOfWork.Contacto.EliminarContacto(idUser,idUsuario);
                    dbTGuardar.Commit();
                } catch (Exception ex) {
                    dbTGuardar.Rollback();
                    throw;
                }
            }
            return LocalRedirect("~/Personal/Contactos");
        }
        public IActionResult Mensajes()
        {
            return View();
        }
        public IActionResult Notificaciones()
        {
            return View();
        }


    }
}