using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUsuarioCVRepositorio : IRepositorio<UsuarioCV> {
        void Update(UsuarioCV obj);
        public void GuardarUsuarioCV(UsuarioCV usuario,CurriculumModelVM model, int idUsuario, FotoUsuarioCV foto);
        public void NuevoUsuarioCV(int idUsuario,int idCurriculum);
    }
}
