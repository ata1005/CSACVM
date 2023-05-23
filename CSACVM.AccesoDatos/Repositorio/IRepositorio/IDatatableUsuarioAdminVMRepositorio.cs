using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio
{
    public interface IDatatableUsuarioAdminVMRepositorio : IRepositorio<DatatableUsuarioAdminVM>
    {
        public List<DatatableUsuarioAdminVM> ObtenerUsuarios();
        public List<DatatableUsuarioAdminVM> ObtenerUsuarios(BusquedaFiltrosUsuario filtros);
    }
}
