using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using CSACVM.Utilidades;

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
            
            return new CookieUserItem {
                IdUsuario = usuario.IdUsuario,
                NombreUser = usuario.NombreUser,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                IdDepartamento = usuario.IdDepartamento,
                //Rol = usuario.Rol.IdRol != null ? usuario.Rol.IdRol : 0,
                //Grupo = usuario.Grupo.IdGrupo != null ? usuario.Grupo.IdGrupo : 0,
                Administrador = usuario.EsAdmin
            };
        }

        public CookieUserItem Register(RegisterVM model)
        {
            
            var hashedPassword = Hasher.GenerateHash(model.Password);
            Departamento userDpto = _db.Departamento.Where(d => d.IdDepartamento == model.IdDepartamento).FirstOrDefault();

            var user = new Usuario
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                NombreUser = model.NombreUser,
                Email = model.Email,
                Password = hashedPassword,
                IdDepartamento = userDpto.IdDepartamento,
                Rol = null,
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
                IdDepartamento = user.Departamento.IdDepartamento,
                IdRol = user.Rol.IdRol,
                IdGrupo = user.Grupo.IdGrupo,
                Administrador = user.EsAdmin
            };
        }

    }
}
