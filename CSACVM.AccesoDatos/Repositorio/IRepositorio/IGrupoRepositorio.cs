using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IGrupoRepositorio : IRepositorio<Grupo> {
        void Update(Grupo obj);
    }
}
