using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IEntradaRepositorio : IRepositorio<Entrada> {
        void Update(Entrada obj);
        public List<ListaEntradaVM> ObtenerListaEntradaVM();
        public void NuevaEntrada(EntradaVM model, int idUser);
    }
}
