using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IAptitudCVRepositorio : IRepositorio<AptitudCV> {
        void Update(AptitudCV obj);
        public List<AptitudCV> ObtenerListaAptitud(int idCurriculum);

    }
}
