using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class FormacionCVRepositorio : Repositorio<FormacionCV>, IFormacionCVRepositorio
    {
        private CSACVMContext _db;
        public FormacionCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(FormacionCV obj)
        {
            _db.FormacionCV.Update(obj);
        }

        public List<FormacionCV> ObtenerListaFormacion(int idCurriculum) => _db.FormacionCV.Where(f => f.IdCurriculum== idCurriculum).ToList();

        public void GuardarFormacion(List<FormacionCV> lstFormacionCV,List<string> lstGradoFormacion, List<string> lstUbicacionFormacion, List<string> lstObservacionesFormacion, List<string> lstDateDesdeFormacion, List<string> lstDateHastaFormacion, int idCurriculum, int idUser) {

            List<string> gradoCambiar = new List<string>();
            List<int> entradaEliminar = new List<int>();
            foreach(FormacionCV formacion in lstFormacionCV) {
                if (lstGradoFormacion.Contains(formacion.Grado)) {
                    gradoCambiar.Add(formacion.Grado);
                } else {
                    //Remove
                    entradaEliminar.Add(formacion.IdFormacionCV);
                }
            }

            //Si no están en la lista que se recibe, se ha eliminado.
            if(entradaEliminar.Count > 0) {
                foreach(int id in entradaEliminar) {
                    FormacionCV formacion = _db.FormacionCV.Where(f => f.IdFormacionCV == id).FirstOrDefault();
                    _db.FormacionCV.Remove(formacion);
                    _db.SaveChanges();
                }
            }
            int contador = 0;
            foreach (string grado in lstGradoFormacion) {
                //Si existe la entrada para ese grado, se actualiza. Si no, se crea una nueva entrada.
                if (gradoCambiar.Contains(grado)) {
                    FormacionCV formacion = _db.FormacionCV.Where(f => f.Grado == grado).FirstOrDefault();
                    formacion.Descripcion = lstObservacionesFormacion[contador];
                    if (lstDateDesdeFormacion[contador] != "") formacion.FechaDesde = Convert.ToDateTime(lstDateDesdeFormacion[contador]);
                    if (lstDateHastaFormacion[contador] != "") formacion.FechaHasta = Convert.ToDateTime(lstDateHastaFormacion[contador]);
                    formacion.Ubicacion = lstUbicacionFormacion[contador];
                    formacion.FechaActualizacion = DateTime.Now;
                    formacion.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
                    formacion.UsuarioActualizacion = idUser;
                    _db.FormacionCV.Update(formacion);
                    _db.SaveChanges();
                } else {
                    FormacionCV formacion = new FormacionCV() {
                        IdCurriculum = idCurriculum,
                        Grado = grado,
                        IdUsuario = idUser,
                        Descripcion = lstObservacionesFormacion[contador],
                        FechaDesde = Convert.ToDateTime(lstDateDesdeFormacion[contador]),
                        FechaHasta = Convert.ToDateTime(lstDateHastaFormacion[contador]),
                        Ubicacion = lstUbicacionFormacion[contador],
                        FechaCreacion = DateTime.Now,
                        ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                        UsuarioCreacion = idUser
                    };
                    _db.FormacionCV.Add(formacion);
                    _db.SaveChanges();
                }
                contador++;
            }
        }

    }
}
