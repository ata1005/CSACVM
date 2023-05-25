using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using Microsoft.AspNetCore.Http;
namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IContactoRepositorio : IRepositorio<Contacto> {
        void Update(Contacto obj);
        public List<Contacto> ObtenerContactosUsuario(int idUsuario);
        public void GuardarContacto(int idUsuario, int contacto);
        public void EliminarContacto(int idUsuario, int contacto);
    }
}
