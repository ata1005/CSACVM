﻿using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;
using System.Reflection;

namespace CSACVM.AccesoDatos.Repositorio{
    public class IdiomaCVRepositorio : Repositorio<IdiomaCV>, IIdiomaCVRepositorio
    {
        private CSACVMContext _db;
        public IdiomaCVRepositorio(CSACVMContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(IdiomaCV obj)
        {
            _db.IdiomaCV.Update(obj);
        }

        public List<IdiomaCV> ObtenerListaIdioma(int idCurriculum) => _db.IdiomaCV.Where(f => f.IdCurriculum == idCurriculum).ToList();

        public void GuardarIdioma(List<IdiomaCV> lstIdiomaCV, List<string> lstIdioma, List<string> lstDescripcionIdioma, List<string> lstNivelIdioma, List<string> lstCentroIdioma, List<string> lstDateDesdeIdioma, List<string> lstDateHastaIdioma, int idCurriculum, int idUser) {
            List<string> descripcionCambiar = new List<string>();
            List<int> entradaEliminar = new List<int>();
            foreach (IdiomaCV idioma in lstIdiomaCV) {
                if (lstDescripcionIdioma.Contains(idioma.Descripcion)) {
                    descripcionCambiar.Add(idioma.Descripcion);
                } else {
                    //Remove
                    entradaEliminar.Add(idioma.IdIdiomaCV);
                }
            }

            //Si no están en la lista que se recibe, se ha eliminado.
            if (entradaEliminar.Count > 0) {
                foreach (int id in entradaEliminar) {
                    IdiomaCV idioma = _db.IdiomaCV.Where(f => f.IdIdiomaCV == id).FirstOrDefault();
                    _db.IdiomaCV.Remove(idioma);
                    _db.SaveChanges();
                }
            }
            int contador = 0;
            foreach (string desc in lstDescripcionIdioma) {
                //Si existe la entrada para ese grado, se actualiza. Si no, se crea una nueva entrada.
                if (descripcionCambiar.Contains(desc)) {
                    IdiomaCV idioma = _db.IdiomaCV.Where(f => f.Descripcion == desc).FirstOrDefault();
                    idioma.Descripcion = lstDescripcionIdioma[contador];
                    if (lstIdioma[contador] != "") idioma.IdIdioma = Convert.ToInt32(lstIdioma[contador]);
                    if (lstDateDesdeIdioma[contador] != "") idioma.FechaDesde = Convert.ToDateTime(lstDateDesdeIdioma[contador]);
                    if (lstDateHastaIdioma[contador] != "") idioma.FechaHasta = Convert.ToDateTime(lstDateHastaIdioma[contador]);
                    idioma.Centro = lstCentroIdioma[contador];
                    idioma.IdNivelIdioma = Convert.ToInt32(lstNivelIdioma[contador]);
                    idioma.FechaActualizacion = DateTime.Now;
                    idioma.ProcesoActualizacion = MethodBase.GetCurrentMethod().Name;
                    idioma.UsuarioActualizacion = idUser;
                    _db.IdiomaCV.Update(idioma);
                    _db.SaveChanges();
                } else {
                    IdiomaCV idioma = new IdiomaCV() {
                        IdCurriculum = idCurriculum,
                        Descripcion = desc,
                        IdUsuario = idUser,
                        Centro = lstCentroIdioma[contador],
                        IdIdioma = lstIdioma[contador] != "" ? Convert.ToInt32(lstIdioma[contador]) : null,
                        FechaDesde = lstDateDesdeIdioma[contador] != "" ? Convert.ToDateTime(lstDateDesdeIdioma[contador]) : null,
                        FechaHasta = lstDateHastaIdioma[contador] != "" ? Convert.ToDateTime(lstDateHastaIdioma[contador]) : null,
                        IdNivelIdioma = Convert.ToInt32(lstNivelIdioma[contador]),
                        FechaCreacion = DateTime.Now,
                        ProcesoCreacion = MethodBase.GetCurrentMethod().Name,
                        UsuarioCreacion = idUser
                    };
                    _db.IdiomaCV.Add(idioma);
                    _db.SaveChanges();
                }
                contador++;
            }
        }

        public void EliminarIdioma(IdiomaCV idiomaCV) {
            _db.IdiomaCV.Remove(idiomaCV);
            _db.SaveChanges();
        }

        public void ClonadoIdiomaCV(Curriculum clonado, CurriculumModelVM model) {
            foreach (IdiomaCV idioma in model.ListaIdiomaCV) {
                IdiomaCV nueva = new IdiomaCV() {
                    IdIdioma = idioma.IdIdioma,
                    IdCurriculum = clonado.IdCurriculum,
                    IdUsuario = idioma.IdUsuario,
                    Descripcion = idioma.Descripcion,
                    FechaDesde = idioma.FechaDesde,
                    FechaHasta = idioma.FechaHasta,
                    Centro = idioma.Centro,
                    IdNivelIdioma = idioma.IdNivelIdioma,
                    FechaCreacion = DateTime.Now,
                    ProcesoCreacion = MethodBase.GetCurrentMethod().Name
                };

                _db.IdiomaCV.Add(nueva);
                _db.SaveChanges();
            }
        }

    }
}
