using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio
{
    public interface IDatatableCurriculumAdminVMRepositorio : IRepositorio<DatatableCurriculumAdminVM>
    {
        public List<DatatableCurriculumAdminVM> ObtenerCurriculums(BusquedaFiltros filtros);
        public List<DatatableCurriculumAdminVM> ObtenerCurriculums();
    }
}
