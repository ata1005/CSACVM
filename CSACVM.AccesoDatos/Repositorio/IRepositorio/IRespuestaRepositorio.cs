using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IRespuestaRepositorio : IRepositorio<Respuesta> {
        void Update(Respuesta obj);
    }
}
