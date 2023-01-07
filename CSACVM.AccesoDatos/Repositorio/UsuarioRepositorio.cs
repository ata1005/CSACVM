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
            var usuarios = _db.Usuario.Where(x => x.NombreUser == model.NombreUser);
            if (model.Password == null) return null;
            var results = usuarios.AsEnumerable()
            .Where(m => m.Password == Hasher.GenerateHash(model.Password))
            .Select(m => new CookieUserItem
            {
                IdUsuario = m.IdUsuario,
                NombreUser = m.NombreUser,
                Nombre = m.Nombre,
                Departamento = _db.Departamento.Where(y => y.IdDepartamento == m.Departamento.IdDepartamento).Select(s => s.Descripcion).FirstOrDefault() ?? "Sin departamento"
            });

            return results.FirstOrDefault();
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
                Departamento = userDpto,
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
                Departamento = user.Departamento.Descripcion
            };
        }

    }
}
