using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class EntradaCVRepositorio : Repositorio<EntradaCV>, IEntradaCVRepositorio
    {
        private CSACVMContext _db;
        public EntradaCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(EntradaCV obj)
        {
            _db.EntradaCV.Update(obj);
        }

        public List<EntradaCV> ObtenerListaEntrada(int idCurriculum) => _db.EntradaCV.Where(f => f.IdCurriculum == idCurriculum).ToList();
        public void GuardarEntrada(List<EntradaCV> lstEntradaCV, List<string> lstPuestoTrabajo, List<string> lstEmpresaAsociada, List<string> lstUbicacionEntrada, List<string> lstObservacionesEntrada, List<string> lstDateDesdeEntrada, List<string> lstDateHastaEntrada, int idCurriculum, int idUser) {
            List<string> puestoCambiar = new List<string>();
            List<int> entradaEliminar = new List<int>();
            int i = 0;
            foreach (EntradaCV entrada in lstEntradaCV) {
                if (lstPuestoTrabajo.Contains(entrada.PuestoTrabajo) && entrada.EmpresaAsociada == lstEmpresaAsociada[i]) {
                    puestoCambiar.Add(entrada.PuestoTrabajo);
                } else {
                    //Remove
                    entradaEliminar.Add(entrada.IdEntradaCV);
                }
                i++;
            }

            //Si no están en la lista que se recibe, se ha eliminado.
            if (entradaEliminar.Count > 0) {
                foreach (int id in entradaEliminar) {
                    EntradaCV entrada = _db.EntradaCV.Where(f => f.IdEntradaCV == id).FirstOrDefault();
                    _db.EntradaCV.Remove(entrada);
                    _db.SaveChanges();
                }
            }
            int contador = 0;
            foreach (string desc in lstPuestoTrabajo) {
                //Si existe la entrada para ese grado, se actualiza. Si no, se crea una nueva entrada.
                if (puestoCambiar.Contains(desc)) {
                    EntradaCV entrada = _db.EntradaCV.Where(f => f.PuestoTrabajo == desc).FirstOrDefault();
                    entrada.PuestoTrabajo = lstPuestoTrabajo[contador];
                    if (lstDateDesdeEntrada[contador] != "") entrada.FechaDesde = Convert.ToDateTime(lstDateDesdeEntrada[contador]);
                    if (lstDateHastaEntrada[contador] != "") entrada.FechaHasta = Convert.ToDateTime(lstDateHastaEntrada[contador]);
                    entrada.EmpresaAsociada = lstEmpresaAsociada[contador];
                    entrada.Ubicacion = lstUbicacionEntrada[contador];
                    entrada.Observaciones = lstObservacionesEntrada[contador];
                    entrada.FechaActualizacion = DateTime.Now;
                    entrada.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
                    entrada.UsuarioActualizacion = idUser;
                    _db.EntradaCV.Update(entrada);
                    _db.SaveChanges();
                } else {
                    EntradaCV entrada = new EntradaCV() {
                        IdCurriculum = idCurriculum,
                        PuestoTrabajo = desc,
                        IdUsuario = idUser,
                        Ubicacion = lstUbicacionEntrada[contador],
                        FechaDesde = Convert.ToDateTime(lstDateDesdeEntrada[contador]),
                        FechaHasta = Convert.ToDateTime(lstDateHastaEntrada[contador]),
                        EmpresaAsociada = lstEmpresaAsociada[contador],
                        Observaciones = lstObservacionesEntrada[contador],
                        FechaCreacion = DateTime.Now,
                        ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                        UsuarioCreacion = idUser
                    };
                    _db.EntradaCV.Add(entrada);
                    _db.SaveChanges();
                }
                contador++;
            }
        }
        public void EliminarEntrada(EntradaCV entradaCV) {
            _db.EntradaCV.Remove(entradaCV);
            _db.SaveChanges();
        }

        public void ClonadoEntradaCV(Curriculum clonado, CurriculumModelVM model) {
            foreach (EntradaCV entrada in model.ListaEntradaCV) {
                EntradaCV nueva = new EntradaCV() {
                    EmpresaAsociada = entrada.EmpresaAsociada,
                    IdCurriculum = clonado.IdCurriculum,
                    IdUsuario = entrada.IdUsuario,
                    Observaciones = entrada.Observaciones,
                    FechaDesde = entrada.FechaDesde,
                    FechaHasta = entrada.FechaHasta,
                    PuestoTrabajo = entrada.PuestoTrabajo,
                    Ubicacion = entrada.Ubicacion,
                    FechaCreacion = DateTime.Now,
                    ProcesoCreacion = MethodBase.GetCurrentMethod().Name
                };

                _db.EntradaCV.Add(nueva);
                _db.SaveChanges();
            }
        }
    }
}
