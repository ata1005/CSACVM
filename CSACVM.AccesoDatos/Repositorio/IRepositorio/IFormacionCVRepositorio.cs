using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IFormacionCVRepositorio : IRepositorio<FormacionCV> {
        void Update(FormacionCV obj);
        public List<FormacionCV> ObtenerListaFormacion(int idCurriculum);
        public void GuardarFormacion(List<FormacionCV> lstFormacionCV,List<string> lstGradoFormacion, List<string> lstUbicacionFormacion, List<string> lstObservacionesFormacion, List<string> lstDateDesdeFormacion, List<string> lstDateHastaFormacion, int idCurriculum, int idUser);
    }
}
