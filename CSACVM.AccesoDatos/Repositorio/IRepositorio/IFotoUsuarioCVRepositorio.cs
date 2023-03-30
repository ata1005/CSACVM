using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IFotoUsuarioCVRepositorio : IRepositorio<FotoUsuarioCV> {
        void Update(FotoUsuarioCV obj);
        public void ChangePhoto(FotoUsuarioCV foto, string fullpath, string guid, string ext, int idUsuario);
        public void AddPhoto(string fullpath, string guid, string ext, int idUsuario, int idCurriculum);
        public void EliminarFotoUsuario(FotoUsuarioCV fotoUsuarioCV);
    }
}
