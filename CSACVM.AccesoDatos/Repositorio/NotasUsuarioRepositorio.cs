using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class NotasUsuarioRepositorio : Repositorio<NotasUsuario>, INotasUsuarioRepositorio
    {
        private CSACVMContext _db;
        public NotasUsuarioRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(NotasUsuario obj)
        {
            _db.NotasUsuario.Update(obj);
        }

        public List<NotasUsuario> ObtenerNotasUsuario(int idUsuario) => _db.NotasUsuario.Where(n => n.IdUsuario == idUsuario).ToList();

        public void GuardarNuevaNota(NotasVM model, int idUsuario) {
            NotasUsuario nota = new NotasUsuario() {
                IdUsuario = idUsuario,
                Descripcion = model.Nota.Descripcion,
                Titulo = model.Nota.Titulo,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = idUsuario,
                ProcesoCreacion = MethodBase.GetCurrentMethod().Name
            };
            _db.NotasUsuario.Add(nota);
            _db.SaveChanges();
        }

        public void EliminarNota(int idNota) {
            NotasUsuario nota = _db.NotasUsuario.Where(n => n.IdNotaUsuario== idNota).FirstOrDefault();
            _db.NotasUsuario.Remove(nota);
            _db.SaveChanges();
        }
        public void EditarNota(NotasVM notavm,int idUsuario) {
            NotasUsuario nota = _db.NotasUsuario.Where(n => n.IdNotaUsuario == notavm.IdNota).FirstOrDefault();
            nota.Titulo = notavm.Nota.Titulo;
            nota.Descripcion = notavm.Nota.Descripcion;
            nota.FechaActualizacion = DateTime.Now;
            nota.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
            _db.NotasUsuario.Update(nota);
            _db.SaveChanges();
        }
    }
}
