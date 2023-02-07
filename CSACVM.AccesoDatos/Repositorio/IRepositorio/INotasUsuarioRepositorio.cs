using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Http;
namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface INotasUsuarioRepositorio : IRepositorio<NotasUsuario> {
        void Update(NotasUsuario obj);
        public List<NotasUsuario> ObtenerNotasUsuario(int idUsuario);
        public void GuardarNuevaNota(NotasVM model, int idUsuario);
        public void EditarNota(NotasVM notavm, int idUsuario);
        public void EliminarNota(int idNota);
    }
}
