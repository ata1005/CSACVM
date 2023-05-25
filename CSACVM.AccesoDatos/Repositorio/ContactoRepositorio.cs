using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class ContactoRepositorio : Repositorio<Contacto>, IContactoRepositorio {
        private CSACVMContext _db;
        public ContactoRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Contacto obj)
        {
            _db.Contacto.Update(obj);
        }

        public List<Contacto> ObtenerContactosUsuario(int idUsuario) => _db.Contacto.Where(n => n.IdUsuario == idUsuario).ToList();

        public void GuardarContacto(int idUsuario, int contacto) {
            Contacto c = new Contacto() {
                IdUsuario = idUsuario,
                IdUsuarioAgregado = contacto,
                FechaCreacion = DateTime.Now,
                ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                UsuarioCreacion = idUsuario
            };
            _db.Contacto.Add(c);
            _db.SaveChanges();
        }

        public void EliminarContacto(int idUsuario, int contacto) {
            Contacto c = _db.Contacto.Where(u => u.IdUsuario== idUsuario && u.IdUsuarioAgregado == contacto).FirstOrDefault();
            if (c!=null) {
                _db.Contacto.Remove(c);
                _db.SaveChanges();
            }
        }
    }
}
