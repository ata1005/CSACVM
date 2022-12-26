using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento> {
        void Update(Departamento obj);
    }
}
