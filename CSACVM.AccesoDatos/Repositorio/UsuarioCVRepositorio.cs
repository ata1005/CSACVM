using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class UsuarioCVRepositorio : Repositorio<UsuarioCV>, IUsuarioCVRepositorio
    {
        private CSACVMContext _db;
        public UsuarioCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(UsuarioCV obj)
        {
            _db.UsuarioCV.Update(obj);
        }

        public void GuardarUsuarioCV(UsuarioCV usuario, CurriculumModelVM model, int idUsuario, FotoUsuarioCV foto) {
            usuario.Nombre = model.UsuarioCV.Nombre;
            usuario.Apellido1 = model.UsuarioCV.Apellido1;
            usuario.Apellido2 = model.UsuarioCV.Apellido2;
            usuario.Email = model.UsuarioCV.Email;
            usuario.EnlaceContacto = model.UsuarioCV.EnlaceContacto;
            usuario.FechaNacimiento = model.UsuarioCV.FechaNacimiento;
            usuario.Nacionalidad = model.UsuarioCV.Nacionalidad;
            usuario.Profesion = model.UsuarioCV.Profesion;
            usuario.Telefono = model.UsuarioCV.Telefono;
            usuario.IdFotoUsuarioCV = foto != null ? foto.IdFotoUsuarioCV : null;
            usuario.UsuarioActualizacion = idUsuario;
            usuario.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
            usuario.FechaActualizacion = DateTime.Now;
            usuario.AcercaDe = model.UsuarioCV.AcercaDe;
            _db.Update(usuario);
            _db.SaveChanges();
        }

        public void NuevoUsuarioCV(int idUsuario,int idCurriculum) {

            UsuarioCV usuario = new UsuarioCV() {
                IdUsuario= idUsuario,
                IdCurriculum = idCurriculum,
                UsuarioCreacion = idUsuario,
                ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                FechaCreacion = DateTime.Now
            };

            _db.UsuarioCV.Add(usuario);
            _db.SaveChanges();
        }

        public void EliminarUsuario(UsuarioCV usuarioCV) {
            _db.UsuarioCV.Remove(usuarioCV);
            _db.SaveChanges();
        }
    }
}
