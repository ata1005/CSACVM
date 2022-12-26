using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IIdiomaRepositorio : IRepositorio<Idioma> {
        void Update(Idioma obj);
    }
}
