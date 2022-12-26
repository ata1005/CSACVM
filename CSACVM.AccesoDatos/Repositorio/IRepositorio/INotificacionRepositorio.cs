using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface INotificacionRepositorio : IRepositorio<Notificacion> {
        void Update(Notificacion obj);
    }
}
