using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using CSACVM.Utilidades;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private CSACVMContext _db;
        public UsuarioRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }

        public bool EsAdmin(int idUsuario) => _db.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario).EsAdmin;
        

        public void Update(Usuario obj)
        {
            _db.Usuario.Update(obj);
        }

        public CookieUserItem ValidarUsuario(LoginVM model)
        {
            Usuario usuario = _db.Usuario.Where(x => x.NombreUser == model.NombreUser).FirstOrDefault();
            if (model.Password == null) return null;
            string userlogin = "";
            string pass = "";
            if (usuario == null) {
                usuario = _db.Usuario.Where(x2 => x2.Email == model.NombreUser).FirstOrDefault();
                if (usuario == null) {
                    return null;
                } else {
                    userlogin = usuario.NombreUser;
                }
            } else {
                userlogin = usuario.NombreUser;
            }
            pass = Hasher.GenerateHash(model.Password);
            usuario = _db.Usuario.Where(x3 => x3.NombreUser == userlogin && x3.Password == pass).FirstOrDefault();
            if (usuario == null) return null;

            return new CookieUserItem {
                IdUsuario = usuario.IdUsuario,
                NombreUser = usuario.NombreUser,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                IdDepartamento = usuario.IdDepartamento,
                IdRol = usuario.IdRol,
                IdGrupo = usuario.IdGrupo,
                Biografia = "",
                Administrador = usuario.EsAdmin
            };
        }

        public CookieUserItem Register(RegisterVM model){
            
            var hashedPassword = Hasher.GenerateHash(model.Password);
            Departamento userDpto = _db.Departamento.Where(d => d.IdDepartamento == model.IdDepartamento).FirstOrDefault();
            Rol userRol = _db.Rol.Where(d => d.IdRol == model.IdRol).FirstOrDefault();
            Grupo userGrupo = _db.Grupo.Where(d => d.IdGrupo == model.IdGrupo).FirstOrDefault();
            var user = new Usuario
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                NombreUser = model.NombreUser,
                Email = model.Email,
                Password = hashedPassword,
                IdDepartamento = userDpto.IdDepartamento,
                IdRol = userRol.IdRol,
                IdGrupo= userGrupo.IdGrupo,
                Biografia = "",
                Activo = true,
                EsAdmin = model.Administrador
            };

            _db.Usuario.Add(user);
            _db.SaveChanges();

            return new CookieUserItem
            {
                IdUsuario = user.IdUsuario,
                NombreUser = user.NombreUser,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                IdDepartamento = user.IdDepartamento,
                IdRol = user.IdRol,
                IdGrupo = user.IdGrupo,
                Biografia = "",
                Administrador = user.EsAdmin
            };
        }

        public void GuardarCambiosPerfil(ProfileVM cambiosPerfil) {
            Usuario user = _db.Usuario.Where(u => u.NombreUser == cambiosPerfil.NombreUser).FirstOrDefault();
            if (user != null) {
                if(cambiosPerfil.Biografia != null) user.Biografia = cambiosPerfil.Biografia;
                _db.Usuario.Update(user);
                _db.SaveChanges();
            }
        }

        public void CambiarPass(ProfileVM cambiosPerfil) {
            Usuario user = _db.Usuario.Where(u => u.NombreUser == cambiosPerfil.NombreUser).FirstOrDefault();
            if (user != null) { 
                user.Password = Hasher.GenerateHash(cambiosPerfil.Password);
                _db.Usuario.Update(user);
                _db.SaveChanges();
            }
        }

        public bool ComprobarPass(string PassActual, string nombre) {
            string hashUser = _db.Usuario.Where(u => u.NombreUser == nombre).Select(u2 => u2.Password).FirstOrDefault();
            if (Hasher.GenerateHash(PassActual) != hashUser) return false;
            return true;
        }

        public void AddPhoto(Usuario user, string fullpath) {
            user.Foto= fullpath;
        }

        public void ActualizarUser(Usuario user, string nombreUser, string nombre, string apellido, bool activo, bool esAdmin) {
            user.NombreUser= nombreUser;
            user.Nombre= nombre;
            user.Apellido= apellido;
            user.Activo= activo;
            user.EsAdmin= esAdmin;
            user.FechaActualizacion = DateTime.Now;
            user.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
            _db.Usuario.Update(user);
            _db.SaveChanges();
        }
    }
}
