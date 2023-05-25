using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio
{
    public interface IDatatableBuscarUsuarioVMRepositorio : IRepositorio<DatatableBuscarUsuarioVM>
    {
        public List<DatatableBuscarUsuarioVM> ObtenerUsuarios(List<Contacto> lstContactos, int idUsuario);
        public List<DatatableBuscarUsuarioVM> ObtenerContactos(List<Contacto> lstContactos, int idUsuario);
    }
}
