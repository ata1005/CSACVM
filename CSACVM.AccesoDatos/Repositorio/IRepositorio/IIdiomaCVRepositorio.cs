using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IIdiomaCVRepositorio : IRepositorio<IdiomaCV> {
        void Update(IdiomaCV obj);
        public List<IdiomaCV> ObtenerListaIdioma(int idCurriculum);
        public void GuardarIdioma(List<IdiomaCV> lstIdiomaCV, List<string> lstIdioma, List<string> lstDescripcionIdioma, List<string> lstNivelIdioma, List<string> lstCentroIdioma, List<string> lstDateDesdeIdioma, List<string> lstDateHastaIdioma, int idCurriculum, int idUser);
        public void EliminarIdioma(IdiomaCV idiomaCV);
    }
}
