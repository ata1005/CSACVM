using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface ILogroCVRepositorio : IRepositorio<LogroCV> {
        void Update(LogroCV obj);
        public List<LogroCV> ObtenerListaLogro(int idCurriculum);
        public void GuardarLogro(List<LogroCV> lstLogroCV, List<string> lstDescripcionLogro, int idCurriculum, int idUser);
        public void EliminarLogro(LogroCV logroCV);
        public void ClonadoLogroCV(Curriculum clonado, CurriculumModelVM model);

    }
}
