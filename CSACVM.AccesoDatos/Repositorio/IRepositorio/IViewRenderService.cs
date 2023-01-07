
namespace CSACVM.AccesoDatos.Repositorio.IRepositorio
{
    public interface IViewRenderService{
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
