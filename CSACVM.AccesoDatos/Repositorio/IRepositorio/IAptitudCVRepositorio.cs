using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IAptitudCVRepositorio : IRepositorio<AptitudCV> {
        void Update(AptitudCV obj);
        public List<AptitudCV> ObtenerListaAptitud(int idCurriculum);
        public void GuardarAptitud(List<AptitudCV> lstAptitudCV, List<string> lstDescripcionAptitud, int idCurriculum, int idUser);
        public void EliminarAptitud(AptitudCV aptitudCV);

    }
}
