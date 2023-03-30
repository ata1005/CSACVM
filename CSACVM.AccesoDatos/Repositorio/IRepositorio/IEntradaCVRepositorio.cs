using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IEntradaCVRepositorio : IRepositorio<EntradaCV> {
        void Update(EntradaCV obj);
        public List<EntradaCV> ObtenerListaEntrada(int idCurriculum);
        public void GuardarEntrada(List<EntradaCV> lstEntradaCV, List<string> lstPuestoTrabajo, List<string> lstEmpresaAsociada, List<string> lstUbicacionEntrada, List<string> lstObservacionesEntrada, List<string> lstDateDesdeEntrada, List<string> lstDateHastaEntrada, int idCurriculum, int idUser);
        public void EliminarEntrada(EntradaCV entradaCV);
        public void ClonadoEntradaCV(Curriculum clonado, CurriculumModelVM model);
    }
}
